<template>
  <div>
    <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/home' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>菜单管理</el-breadcrumb-item>
      <el-breadcrumb-item>菜单列表</el-breadcrumb-item>
    </el-breadcrumb>

    <!-- 卡片视图区域 -->
    <el-card>

      <!-- 搜索与添加区域 -->
      <el-row :gutter="20">
        <el-col :span="8">
          <el-input placeholder="请输入内容" v-model="queryInfo.query" clearable @clear="getMenuList">
            <el-button slot="append" icon="el-icon-search" @click="getMenuList"></el-button>
          </el-input>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="addDialogVisible = true">添加</el-button>
        </el-col>
      </el-row>

      <!-- 列表区域 -->
      <el-table
        :data="tableData"
        border
        stripe
        row-key="id"
        :tree-props="{ children: 'children', hasChildren: 'hasChildren' }"
      >
        <el-table-column label="菜单名称" header-align="center" align="center" prop="name"></el-table-column>
        <el-table-column label="菜单路径" header-align="center" align="center" prop="path"></el-table-column>
        <el-table-column label="创建时间" header-align="center" align="center" prop="createTime"></el-table-column>
        <el-table-column label="状态" header-align="center" align="center">
          <template slot-scope="scope">
            <el-switch v-model="scope.row.enabled" @change="enabledChanged(scope.row)"></el-switch>
          </template>
        </el-table-column>
        <el-table-column label="操作" header-align="center" width="180px">
          <template slot-scope="scope">
            <el-button type="primary" icon="el-icon-edit" size="mini" @click="edit(scope.row.id)"></el-button>
            <el-button type="danger" icon="el-icon-delete" size="mini" @click="del(scope.row.id)"></el-button>
          </template>
        </el-table-column>
      </el-table>

      <!-- 分页区域 -->
      <el-pagination
        :current-page="queryInfo.pageIndex"
        :page-sizes="[20, 30, 50, 100]"
        :page-size="queryInfo.pageSize"
        :total="total"
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        layout="total, sizes, prev, pager, next, jumper"
      ></el-pagination>

      <!-- 编辑对话框 -->
      <el-dialog title="编辑菜单" :visible.sync="addDialogVisible" width="50%" @close="dialogClosed">
        <!-- 内容主体区域 -->
        <el-form
          :model="menuForm"
          :rules="menuFormRules"
          ref="menuFormRef"
          label-width="70px"
        >
          <el-form-item label="父级菜单" label-width="100px">
            <el-select v-model="menuForm.parentId" clearable placeholder="请选择">
              <el-option
                v-for="item in parentMenuOptions"
                :key="item.value"
                :label="item.label"
                :value="item.value"
              ></el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="菜单名称" prop="name" label-width="100px">
            <el-input v-model="menuForm.name"></el-input>
          </el-form-item>
          <el-form-item label="路径" label-width="100px">
            <el-input v-model="menuForm.name"></el-input>
          </el-form-item>
          <el-form-item label="编码" label-width="100px">
            <el-input v-model="menuForm.code"></el-input>
          </el-form-item>
          <el-form-item label="Icon" label-width="100px">
            <el-input v-model="menuForm.icon"></el-input>
          </el-form-item>
          <el-form-item label="排序号" label-width="100px">
            <el-input-number v-model="menuForm.sort" :min="1" :max="10000"></el-input-number>
          </el-form-item>
          <el-form-item label="状态" label-width="100px">
            <el-switch
              style="display: block;margin-top:9px;"
              v-model="menuForm.enabled"
              active-color="#13ce66"
              inactive-color="#ff4949"
            ></el-switch>
          </el-form-item>
        </el-form>
        <!-- 底部区域 -->
        <span slot="footer" class="dialog-footer">
          <el-button @click="addDialogVisible = false">取 消</el-button>
          <el-button type="primary" @click="addMenu">确 定</el-button>
        </span>
      </el-dialog>

    </el-card>
  </div>
</template>

<script>
export default {
  data () {
    return {
      addDialogVisible: false,
      queryInfo: {
        query: '',
        pageIndex: 1,
        pageSize: 20
      },
      total: 0,
      menuForm: {
        id: '',
        parentId: '',
        name: '',
        path: '',
        code: '',
        icon: '',
        sort: '',
        enabled: ''
      },
      menuFormRules: {
        name: [{ required: true, message: '请输入菜单名称', trigger: 'blur' }]
      },
      parentMenuOptions: [],
      tableData: [
        {
          id: 1,
          name: '菜单管理',
          path: '',
          createTime: '',
          enabled: true,
          children: [
            {
              id: 100,
              name: '菜单列表',
              path: '',
              createTime: '',
              enabled: true
            }
          ]
        }
      ]
    }
  },
  methods: {
    async getMenuList () {
      const { data: res } = await this.$http.get('', { params: this.queryInfo })
      if (res.meta.status !== 200) {
        return this.$message.error('获取列表失败...')
        this.tableData = res.data.users
        this.total = res.data.total
      }
    },
    addMenu () {
      this.$refs.menuFormRef.validate(async (valid) => {
        if (!valid) return
        const { data: res } = await this.$http.post('', this.menuForm)
        if (res.meta.status !== 200) {
          this.$message.error('操作失败...')
        }
        this.$message.success('操作成功...')
      })
    },
    async edit (id) {
      const { data: res } = await this.$http.get('')
      if (res.meta.status !== 200) {
        this.$message.error('查询失败...')
      }
      this.menuForm = res.data
      this.addDialogVisible = true
    },
    async del (id) {
      const { data: res } = await this.$http.get('')
      if (res.meta.status !== 200) {
        this.$message.error('删除失败...')
      }
    },
    async enabledChanged (row) {
      const { data: res } = await this.$http.get('')
      if (res.meta.status !== 200) {
        row.enabled=!row.enabled
        return this.$message.error('查询用户信息失败！')
      }
    },
    dialogClosed () {
      this.$refs.menuFormRef.resetFields()
    },
    // 监听 pageSize 改变的事件
    handleSizeChange (size) {
      this.queryInfo.pageSize = size
      this.getMenuList()
    },
    // 监听 pageIndex 改变的事件
    handleCurrentChange (index) {
      this.queryInfo.pageIndex = index
      this.getMenuList()
    }
  },
  created () {
    // this.getMenuList()
  }
}
</script>

<style lang="less" scoped></style>

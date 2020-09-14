<template>
  <div>
    <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/home' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>角色管理</el-breadcrumb-item>
      <el-breadcrumb-item>角色列表</el-breadcrumb-item>
    </el-breadcrumb>

    <!-- 卡片视图区域 -->
    <el-card>
      <!-- 搜索与添加区域 -->
      <el-row :gutter="20">
        <el-col :span="8">
          <el-input placeholder="请输入内容" v-model="queryInfo.query" clearable @clear="getRoleList">
            <el-button slot="append" icon="el-icon-search" @click="getRoleList"></el-button>
          </el-input>
        </el-col>
        <el-col :span="8">
          <el-button type="primary" icon="el-icon-fa-plus" @click="addDialogVisible = true">添加</el-button>
          <el-button type="danger" icon="el-icon-delete" @click="dels">删除</el-button>
          <el-button type="warning" icon="el-icon-fa-edit" @click="enableds">状态修改</el-button>
        </el-col>
      </el-row>

      <!-- 列表区域 -->
      <el-table :data="tableData" border size="medium" v-on:selection-change="selectionChange">
        <el-table-column type="selection" :selectable="checkSelect" width="40"></el-table-column>
        <el-table-column
          header-align="center"
          align="center"
          prop="id"
          v-if="false"
          label="Id"
          width="80"
        ></el-table-column>
        <el-table-column header-align="center" align="center" prop="name" label="角色名称"></el-table-column>
        <el-table-column header-align="center" prop="enabled" width="80" label="状态">
          <template slot-scope="scope">
            <el-button
              :type="scope.row.enabled ? 'success' : 'danger'"
              size="mini"
            >{{scope.row.enabled?"启用":"禁用" }}</el-button>
          </template>
        </el-table-column>
        <el-table-column header-align="center" align="center" prop="sort" label="排序号" width="80"></el-table-column>
        <el-table-column
          header-align="center"
          align="center"
          prop="createTime"
          label="创建时间"
          width="200"
        ></el-table-column>
        <el-table-column header-align="center" label="操作" width="200">
          <template slot-scope="scope">
            <el-button
              :disabled="scope.row.name == 'admin'"
              v-on:click="edit(scope.row)"
              type="primary"
              plain
              size="mini"
            >编辑</el-button>
            <el-button v-on:click="roleMenu(scope.row)" type="primary" plain size="mini">角色菜单</el-button>
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
      <el-dialog title="编辑角色" :visible.sync="addDialogVisible" width="50%" @close="dialogClosed">
        <!-- 内容主体区域 -->
        <el-form :model="roleForm" :rules="roleFormRules" ref="roleFormRef" label-width="70px">
          <el-form-item label="角色名称" prop="name" label-width="100px">
            <el-input v-model="roleForm.name"></el-input>
          </el-form-item>
          <el-form-item label="排序号" label-width="100px">
            <el-input-number v-model="roleForm.sort" :min="1" :max="10000"></el-input-number>
          </el-form-item>
          <el-form-item label="状态" label-width="100px">
            <el-switch
              style="display: block;margin-top:9px;"
              v-model="roleForm.enabled"
              active-color="#13ce66"
              inactive-color="#ff4949"
            ></el-switch>
          </el-form-item>
        </el-form>
        <!-- 底部区域 -->
        <span slot="footer" class="dialog-footer">
          <el-button @click="addDialogVisible = false">取 消</el-button>
          <el-button type="primary" @click="addRole">确 定</el-button>
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
      roleForm: {
        id: 0,
        name: '',
        sort: 0,
        enabled: true
      },
      roleFormRules: {
        name: [{ required: true, message: '请输入菜单名称', trigger: 'blur' }]
      },
      ids: [],
      tableData: []
    }
  },
  methods: {
    async getRoleList () {
      const { data: res } = await this.$http.get('', { params: this.queryInfo })
      if (res.meta.status !== 200) {
        return this.$message.error('获取列表失败...')
        this.tableData = res.data.users
        this.total = res.data.total
      }
    },
    async dels () {
      if (this.ids.length <= 0) {
        this.$message.warning('请选择数据...')
        return
      }
      const { data: res } = await this.$http.get('')
      if (res.meta.status !== 200) {
        this.$message.error('操作失败...')
      }
      this.$message.success('操作成功...')
    },
    async enableds () {
      if (this.ids.length <= 0) {
        this.$message.warning('请选择数据...')
        return
      }
      const { data: res } = await this.$http.get('')
      if (res.meta.status !== 200) {
        this.$message.error('操作失败...')
      }
      this.$message.success('操作成功...')
    },
    async addRole () {
      this.$refs.roleFormRef.validate(async (valid) => {
        if (!valid) return
        const { data: res } = await this.$http.post('', this.menuForm)
        if (res.meta.status !== 200) {
          this.$message.error('操作失败...')
        }
        this.$message.success('操作成功...')
      })
    },
    dialogClosed () {
      this.$refs.roleFormRef.resetFields()
    },
    checkSelect (row, index) {
      return row.name != 'admin'
    },
    selectionChange () {
      var idArr = []
      if (rows) {
        for (let i = 0; i < rows.length; i++) {
          const row = array[i];
          idArr.push(row.id)
        }
        this.ids = idArr
      }
    },
    // 监听 pageSize 改变的事件
    handleSizeChange (size) {
      this.queryInfo.pageSize = size
      this.getRoleList()
    },
    // 监听 pageIndex 改变的事件
    handleCurrentChange (index) {
      this.queryInfo.pageIndex = index
      this.getRoleList()
    }
  },
  created () {}
}
</script>

<style lang="less" scoped>
</style>

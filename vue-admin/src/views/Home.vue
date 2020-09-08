<template>
<el-container class="home-container">
    <!-- 头部区域 -->
    <el-header>
        <div>
            <!-- 黑马logo -->
            <img src="../assets/home.png" alt />
            <!-- 顶部标题 -->
            <span>后台管理系统</span>
        </div>
        <el-button type="info" @click="logout">退出</el-button>
    </el-header>
    <!-- 页面主体区域 -->
    <el-container>
        <!-- 侧边栏 -->
        <el-aside :width="isCollapse ? '70px' : '200px'">
            <div class="toggle-button" @click="toggleCollapse">|||</div>
            <!-- 侧边栏菜单 -->
            <el-menu background-color="#333744" text-color="#fff" active-text-color="#409EFF" unique-opened :collapse="isCollapse" :collapse-transition="false" router :default-active="activePath">
                <!-- 一级菜单 -->
                <el-submenu index="1">
                    <!-- 一级菜单模板 -->
                    <template slot="title">
                        <i class="el-icon-s-tools"></i>
                        <span>账号管理</span>
                    </template>
                    <!-- 二级子菜单 -->
                    <el-menu-item index="/account" @click="saveNavState('/account')">
                        <!-- 二级菜单模板 -->
                        <template slot="title">
                            <i class="el-icon-s-grid"></i>
                            <span>账号列表</span>
                        </template>
                    </el-menu-item>
                </el-submenu>
                <el-submenu index="2">
                    <!-- 一级菜单模板 -->
                    <template slot="title">
                        <i class="el-icon-s-custom"></i>
                        <span>角色管理</span>
                    </template>
                    <!-- 二级子菜单 -->
                    <el-menu-item index="/role" @click="saveNavState('/role')">
                        <!-- 二级菜单模板 -->
                        <template slot="title">
                            <i class="el-icon-s-grid"></i>
                            <span>角色列表</span>
                        </template>
                    </el-menu-item>
                </el-submenu>
                <el-submenu index="3">
                    <!-- 一级菜单模板 -->
                    <template slot="title">
                        <i class="el-icon-menu"></i>
                        <span>菜单管理</span>
                    </template>
                    <!-- 二级子菜单 -->
                    <el-menu-item index="/menu" @click="saveNavState('/menu')">
                        <!-- 二级菜单模板 -->
                        <template slot="title">
                            <i class="el-icon-s-grid"></i>
                            <span>菜单列表</span>
                        </template>
                    </el-menu-item>
                </el-submenu>
                <el-submenu index="4">
                    <!-- 一级菜单模板 -->
                    <template slot="title">
                        <i class="el-icon-folder"></i>
                        <span>组件</span>
                    </template>
                    <!-- 二级子菜单 -->
                    <el-menu-item index="/editor" @click="saveNavState('/editor')">
                        <!-- 二级菜单模板 -->
                        <template slot="title">
                            <i class="el-icon-s-grid"></i>
                            <span>富文本编辑器</span>
                        </template>
                    </el-menu-item>
                </el-submenu>
            </el-menu>
        </el-aside>
        <!-- 主体结构 -->
        <el-main>
            <router-view></router-view>
        </el-main>
    </el-container>
</el-container>
</template>

<script>
export default {
  data () {
    return {
      isCollapse: false,
      activePath: ''
    }
  },
  methods: {
    logout () {
      window.sessionStorage.clear()
      this.$router.push('/login')
    },
    toggleCollapse () {
      this.isCollapse = !this.isCollapse
    },
    saveNavState (activePath) {
      window.sessionStorage.setItem('activePath', activePath)
      this.activePath = activePath
    }
  },
  created () {
    this.activePath = window.sessionStorage.getItem('activePath')
  }
}
</script>

<style lang="less" scoped>
.home-container {
    height: 100%;
}

.el-header {
    background-color: #373d41;
    display: flex;
    justify-content: space-between;
    padding-left: 0;
    align-items: center;
    color: #fff;
    font-size: 20px;

    >div {
        display: flex;
        align-items: center;

        span {
            margin-left: 15px;
        }
    }
}

.el-aside {
    background-color: #333744;

    .el-menu {
        border-right: none;
    }
}

.el-main {
    background-color: #eaedf1;
}

.iconfont {
    margin-right: 10px;
}

.toggle-button {
    background-color: #4a5064;
    font-size: 10px;
    line-height: 24px;
    color: #fff;
    text-align: center;
    letter-spacing: 0.2em;
    cursor: pointer;
}
</style>

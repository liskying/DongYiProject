<template>
  <div id="app">
    <el-container>
      <el-header>Header</el-header>
      <el-container>
        <el-aside>
          <el-menu :default-openeds="['1','2','3']" @select="openPage">
            <el-submenu index="1">
              <template slot="title">
                <el-radio-group v-model="isCollapse" style="margin-bottom: 20px;">
                  <el-radio-button :label="false">展开</el-radio-button>
                  <el-radio-button :label="true">收起</el-radio-button>
                </el-radio-group>
              </template>
            </el-submenu>
            <el-submenu index="2">
              <template slot="title">
                <i class="el-icon-message"></i>组件
              </template>

              <el-menu-item-group>
                <template slot="title">表格</template>
                <el-menu-item index="2-1">
                  <a href="#table1">普通表</a>
                  </el-menu-item>
                <el-menu-item index="2-2">                  
                  <a href="#table5">展开表</a>
                  </el-menu-item>
              </el-menu-item-group>

              <el-menu-item-group title="分组2">
                <el-menu-item index="2-3">选项3</el-menu-item>
              </el-menu-item-group>

              <el-submenu index="2-4">
                <template slot="title">选项4</template>
                <el-menu-item index="2-4-1">选项4-1</el-menu-item>
              </el-submenu>

            </el-submenu>
            <el-submenu index="3">
              <template slot="title"><i class="el-icon-menu"></i>导航二</template>
              <el-menu-item-group>
                <template slot="title">分组一</template>
                <el-menu-item index="3-1">选项1</el-menu-item>
                <el-menu-item index="3-2">选项2</el-menu-item>
              </el-menu-item-group>
              <el-menu-item-group title="分组2">
                <el-menu-item index="3-3">选项3</el-menu-item>
              </el-menu-item-group>
              <el-submenu index="3-4">
                <template slot="title">选项4</template>
                <el-menu-item index="3-4-1">选项4-1</el-menu-item>
              </el-submenu>
            </el-submenu>
          </el-menu>
        </el-aside>
        <el-main>
          <router-view/>
        </el-main>
      </el-container>
      <el-footer>Footer</el-footer>
    </el-container>
  </div>
</template>

<script>
export default {
  data () {
    name: 'app'
  },
  methods : {
    openPage:function(){
      //alert(1);
    }
  }
}
</script>

<style>
#app {
  font-family: 
    "Helvetica Neue",
    "Helvetica",
    "PingFang SC",
    "Hiragino Sans GB",
    "Microsoft YaHei",
    "微软雅黑",
    "Arial",
    "sans-serif";
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
 .el-header,
 .el-footer {
    background-color: #409EFF;
    color: rgb(241, 235, 235);
    text-align: left;
    line-height: 60px;

  }
  
  .el-aside {
    background-color: #409EFF;
    color: #333;
    text-align: left;
    width:180px;
    line-height: 560px;
  }
  
  .el-main {
    background-color: rgb(245, 248, 250);
    text-align: left;
    line-height: 100%;
  }
  
 
</style>

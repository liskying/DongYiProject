<template>
  <el-row>
    <el-col :span="24">
      <div class="btn-container">
          <el-button  size="mini" type="primary" icon="el-icon-add">新增</el-button>
          <el-button  size="mini" type="warning" icon="el-icon-edit">编辑</el-button>
          <el-button  size="mini" type="danger" ricon="el-icon-delete">删除</el-button>
      </div>
      <div >
        <el-table :data="tableData"  
          style="width: 100%"
          border
          height="500"
          stripe>
          <el-table-column prop="date" label="日期" width="140">
          </el-table-column>
          <el-table-column prop="name" label="姓名" width="120">
          </el-table-column>
          <el-table-column prop="address" label="地址">
          </el-table-column>
          <el-table-column
            fixed="right" label="操作"  width="100">
            <template slot-scope="scope">
              <el-button @click="handleClick(scope.row)" type="text" size="small">查看</el-button>
              <el-button type="text" size="small">编辑</el-button>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </el-col>
  </el-row>
</template>
<style>
  .btn-container{
    text-align: right;
    padding: 4px;
    margin-bottom: 10px;
  }
</style>

<script>
  export default {
    methods: {
      handleClick(row) {
        alert(row.address);
        console.log(row);
      }
    },
    data() {
      const item = {
        date: '2016-05-02',
        name: '王小虎',
        address: '上海市普陀区金沙江路 1518 弄'
      };
      return {
        tableData: Array(20).fill(item)
      }
    }
  };
</script>
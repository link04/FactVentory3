<template>

<el-container >
  <el-header>
    <h1>FactVentory</h1>
  </el-header>
  <el-container >
    <el-aside  >
      <navegationmenu ></navegationmenu>
    </el-aside>
    <el-container>
      <el-main>
        <el-row>
          <el-col :span="24">

            <router-view style="padding-left:2%;padding-right:2%;" ></router-view>
            
          </el-col>
        </el-row>
      </el-main>
      <el-footer >
        © <a target="_blank" href="https://www.linkedin.com/in/maximo-alexander-bautista-480786a6/">{{ 'Desarrollo por Maximo Bautista ' + new Date().getFullYear() }}</a>
        </el-footer>
    </el-container>
  </el-container>
</el-container>
</template>

<script>
import navegationmenu from "@/components/shared/NavegationMenu";

export default {
  components: {
    navegationmenu
  },
  props: {
    source: String
  }
};
</script>
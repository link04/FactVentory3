<template>

<el-container >
  <el-header>
    <h1>FactVentory</h1>
  </el-header>
  <el-container   >
    <el-aside style="width:235px;" >
      <navegationmenu ></navegationmenu>
    </el-aside>
    <el-container >
      <el-main  >
        <el-row>
          <el-col >

            <router-view   ></router-view>
            
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
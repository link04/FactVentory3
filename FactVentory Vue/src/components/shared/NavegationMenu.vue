<template>

<el-menu default-active="0" >
 

        <p class="menu-title" ><em >Menu Principal</em></p>

    <template   v-for="item, i in items">
    
       <el-submenu   :index="i.toString()" v-if="item.children !== undefined"  >
            <template slot="title">
                <i :class="'fa fa-' + item.icon"></i>
                <span>{{ item.text }}</span>
            </template>
            <el-menu-item-group title="Opciones">
                <el-menu-item v-for="child, c in item.children" :index="(i.toString() + c)" @click="redirect(child.path)">
                    <i :class="'fa fa-' + child.icon"></i> <span>{{ child.text }}</span>
                </el-menu-item>
            </el-menu-item-group>    
        </el-submenu>
        <el-menu-item   index="2"  v-if="item.children === undefined" @click="redirect(item.path)">
          
            <i :class="'fa fa-' + item.icon"></i>
            
            <span  >{{ item.text }}</span>
            
        </el-menu-item>
    </template>
</el-menu>


</template>

<script>
export default {
  name: "NavegationMenu",
  data: () => ({
    items: [
      { icon: "dashboard", text: "Dashboard", path: "/" },
      { icon: "user", text: "Clientes", path: "/costumers" },
      { icon: "apple", text: "Productos", path: "/products" },
      { icon: "briefcase", text: "Companias", path: "/companies" },
     
      

       /*
       {
        icon: "user",
        text: "Clientes",
        children: [
          { icon: "plus", text: "Agregar", path: "/costumers/add" },    
          { icon: "list", text: "Listar", path: "/costumers" }
          ]
 
      },
      {
        icon: "apple",
        text: "Productos",
        children: [
          { icon: "plus", text: "Agregar", path: "/products/add" },    
          { icon: "list", text: "Listar", path: "/products" }
          ]
      },
       {
        icon: "briefcase",
        text: "Companias",
        children: [
          { icon: "plus", text: "Agregar", path: "/companies/add" },    
          { icon: "list", text: "Listar", path: "/companies" }
          ]
 
      }
      ,
      {
        icon: "star",
        text: "Ejemplo",
        children: [{ icon: "list", text: "Listar", path: "/example" }]
      },
      {
        icon: "wrench",
        text: "Configuración",
        children: [
          { icon: "list", text: "Opción 1", path: "/configuration/opcion1" },
          { icon: "list", text: "Opción 2", path: "/configuration/opcion2" }
        ]
      }*/
    ]
  }),
  methods: {
    
    redirect(path) {
      if(path === undefined) return;
      this.$router.push(path);
    }
  }
};
</script>
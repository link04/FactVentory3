<template>
<div >
<h2>Vendedores</h2>

<div   style="margin: 15px 0"  >
<el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/companies/add`)">Agregar Vendedor</el-button>
</div>
 <el-table   stripe  v-loading="loading" :data="data" height="480"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

   <el-table-column prop="companyName"  label="Vendedor" sortable> </el-table-column>
      <el-table-column prop="email"  label="Email" sortable></el-table-column>
      <el-table-column prop="phoneNumber"  label="Telefono"  sortable></el-table-column>
      <!--<el-table-column prop="address"  label="Direccion" sortable></el-table-column>-->

     <el-table-column align="center">
    
<template slot-scope="scope" >
<el-button icon="el-icon-edit"  type="warning" title="Editar" @click="$router.push(`/companies/${scope.row.companyId}/edit`)"></el-button>
<el-button  icon="el-icon-delete" type="danger" title="Eliminar" @click="remove(scope.row.companyId)">  </el-button>
  </template> 
     </el-table-column>


  </el-table>
<!-- 
  <div style="margin-top: 20px"> 
    
<el-button icon="el-icon-edit" type="warning" @click="$router.push(`/companies/${currentRow.companyId}/edit`)">Editar</el-button>
    
<el-button icon="el-icon-delete" type="danger" title="Eliminar" @click="remove(`${currentRow.companyId}`)" >Eliminar</el-button>

<el-button   title="Eliminar" @click="setCurrent()">Deseleccionar</el-button>

  </div>
-->
</div>
</template>

<script>
export default {
  name: "CompanyIndex",
  data() {
    return {
      data: [],
      loading: false
    };
  },
  created() {
    let self = this;
    self.getAll();
  },
  methods: {/*
     setCurrent(row) {
        this.$refs.singleTable.setCurrentRow(row);
      },
      handleCurrentChange(val) {
        this.currentRow = val;
      },*/
    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.companyService
        .getAll()
        .then(r => {
          self.loading = false;
          self.data = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    },
    remove(id) {
      let self = this;

      self
        .$confirm("Estas seguro de realizar esta acción?", "Confirmación", {
          confirmButtonText: "Si",
          cancelButtonText: "Cancelar",
          type: "warning"
        })
        .then(() => {
          _remove();
          this.$message({
            type: "success",
            message: "Acción exitosa"
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "Acción cancelada"
          });
     });
          function _remove() {
            self.$store.state.services.companyService
              .remove(id)
              .then(r => {
                self.loading = false;
                self.getAll();
              })
              .catch(r => {
                self.$message({
                  message: "Ocurrio un error inesperado.",
                  type: "error"
                });
              });
          }
      
    }
  }
};
</script>
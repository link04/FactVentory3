<template>
<div >

  
<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading"><h2>Vendedores</h2></div>
  <div   style="margin: 15px 0" class="panel-body">
<el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/salesPersons/add`)">Agregar Vendedor</el-button>
  </div>
  
 <el-table   size="small"  height="440px" stripe  v-loading="loading" :data="data"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

   <el-table-column prop="companyName"  label="Vendedor" sortable> </el-table-column>
      <el-table-column prop="email"  label="Email" sortable></el-table-column>
      <el-table-column prop="phoneNumber"  label="Telefono"  sortable></el-table-column>
      <!--<el-table-column prop="address"  label="Direccion" sortable></el-table-column>-->

     <el-table-column align="center">
    
<template slot-scope="scope" >
      <el-tooltip class="item" effect="dark" content="Editar" placement="top-start">
<el-button icon="el-icon-edit"  type="warning"  @click="$router.push(`/salesPersons/${scope.row.companyId}/edit`)"></el-button>
   </el-tooltip>
    <el-tooltip class="item" effect="dark" content="Eliminar" placement="top-start">
<el-button  icon="el-icon-delete" type="danger"  @click="remove(scope.row.companyId)">  </el-button>
  </el-tooltip>
  </template> 
     </el-table-column>
  </el-table>
  </div>

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
    self.getAllCP();
  },
  methods: {
    getAllCP() {
      let self = this;
      self.loading = true;
      self.$store.state.services.companyService
        .getAllCP()
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
                self.getAllCP();
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
<template>
<div >
<h2>Clientes</h2>

<div   style="margin: 15px 0" >
<el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/costumers/add`)">Agregar Cliente</el-button>

</div>
 <el-table   stripe  v-loading="loading" :data="data" height="480"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

      <el-table-column prop="fullName"  label="Cliente"  sortable> </el-table-column>
          
      <el-table-column prop="email"  label="Email"  sortable></el-table-column>
      <el-table-column prop="phoneNumber"  label="Telefono"  sortable></el-table-column>
      <el-table-column prop="address"  label="Direccion" sortable></el-table-column>

     <el-table-column align="center">
       
<template slot-scope="scope" >
<el-button icon="el-icon-edit"  type="warning" title="Editar" @click="$router.push(`/costumers/${scope.row.costumerId}/edit`)"></el-button>
<el-button  icon="el-icon-delete" type="danger" title="Eliminar" @click="remove(scope.row.costumerId)">  </el-button>
  </template>
     </el-table-column>

    </el-table>
</div>
</template>

<script>
export default {
  name: "CostumerIndex",
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
  methods: {
    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.costumerService
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
            self.$store.state.services.costumerService
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
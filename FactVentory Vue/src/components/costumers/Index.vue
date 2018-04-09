<template>
<div >
<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading"><h2>Clientes</h2></div>
  <div   style="margin: 15px 0" class="panel-body">
   <el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/costumers/add`)">Agregar Cliente</el-button>

  </div>



  <el-table   height="440px" stripe  v-loading="loading" :data="data"   highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

      <el-table-column prop="fullName"  label="Cliente"  sortable> </el-table-column>
          
      <el-table-column prop="email"  label="Email"  sortable></el-table-column>
      <el-table-column prop="phoneNumber"  label="Telefono"  sortable></el-table-column>
      <el-table-column prop="address"  label="Direccion" sortable></el-table-column>

     <el-table-column align="center">
       
<template slot-scope="scope" >
        <el-tooltip class="item" effect="dark" content="Editar" placement="top-start">
<el-button icon="el-icon-edit"  type="warning"  @click="$router.push(`/costumers/${scope.row.costumerId}/edit`)"></el-button>
        </el-tooltip>
              <el-tooltip class="item" effect="dark" content="Eliminar" placement="top-start">
<el-button  icon="el-icon-delete" type="danger"  @click="remove(scope.row.costumerId)">  </el-button>
              </el-tooltip>
  </template>
     </el-table-column>

    </el-table>
</div>

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
    self.getAllCM();
  },
  methods: {
    getAllCM() {
      let self = this;
      self.loading = true;
      self.$store.state.services.costumerService
        .getAllCM()
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
            self.getAllCM();
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
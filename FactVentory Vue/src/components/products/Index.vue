<template>
<div >
<h2>Productos</h2>

<div   style="margin: 15px 0" >
<el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/products/add`)">Agregar Producto</el-button>

</div>


 <el-table   stripe  v-loading="loading" :data="data" height="480"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

      <el-table-column prop="productName"  label="Producto"  sortable> </el-table-column>
      <el-table-column prop="unitPrice"  label="Precio por Unidad"  sortable></el-table-column>
      <el-table-column prop="quantity"  label="Cantidad Disponible"  sortable></el-table-column>
      <el-table-column prop="description"  label="Descripcion"  sortable></el-table-column>
     <el-table-column align="center">
<template slot-scope="scope" >
<el-button icon="el-icon-edit"  type="warning" title="Editar" @click="$router.push(`/products/${scope.row.productId}/edit`)"></el-button>
<el-button  icon="el-icon-delete" type="danger" title="Eliminar" @click="remove(scope.row.productId)">  </el-button>
  </template>
     </el-table-column>
     
    </el-table>
</div>
</template>

<script>
export default {
  name: "ProductIndex",
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
      self.$store.state.services.productService
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
            self.$store.state.services.productService
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
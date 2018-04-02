<template>
<div>
 <el-table  size="small" stripe   v-loading="loading" :data="data" height="200px"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

      <el-table-column prop="productId"  label="Producto"  sortable></el-table-column>
      <el-table-column prop="unitPrice"  label="Precio"  sortable></el-table-column>
      <el-table-column prop="quantity"  label="Cantidad"  sortable></el-table-column>
      <el-table-column prop="total"  label="Total"  sortable></el-table-column>     

    </el-table>
    </div>
</template>

<script >
var moment=require('moment');


export default {
   
  name: "InvoiceDetailIndex",
  data() {
    return {
      moment:moment,
      data: [
     

      ],
      
      loading: false
    };
  },
  created() {
    let self = this;
    self.getAll();
    
  }, 
  mounted:function(){
        this.myDate() 
  } ,
  methods: {
   get(id) {
     if(id == undefined)return;

      let self = this;    

       self.loading = true;
       self.$store.state.services.costumerService
            .get(id)
            .then(r => {
              self.loading = false;
              self.form.productId = r.data.productId;
              self.form.quantity = r.data.quantity;
              self.form.unitPrice = r.data.unitPrice;
              self.form.total = r.data.total;
             
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
            self.$store.state.services.invoiceDetailService
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
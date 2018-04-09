<template >
<div>

  <el-table size="mini" stripe  :data="data" height="200px" ref="LaSuma"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">
    
         <el-table-column prop="productId"  label="Productos" sortable>   </el-table-column>
         <el-table-column prop="unitPrice"  label="Precio"  sortable>   </el-table-column>
         <el-table-column prop="quantity"  label="Cantidad"   sortable></el-table-column>
         <el-table-column prop="total"   label="Total" sortable></el-table-column>  
   
    <el-table-column >
<template slot-scope="scope" >
              <el-tooltip class="item" effect="dark" content="Eliminar" placement="top-start">
<el-button style="height:40px;"  v-show="scope.row.invoiceId  === 0 "  icon="el-icon-delete" type="danger"  @click="remove(scope.row.invoiceDetailId)">  </el-button>
              </el-tooltip>
  </template>
     </el-table-column>

    </el-table>
          <el-button   v-if=" id2 < 1 " icon="el-icon-refresh" size="mini" @click="reload" type="primary">Actualizar</el-button>
   
        

    </div>
    
</template>

<script >
var moment = require("moment");
export default {
  name: "InvoiceDetailIndex",
  data() {
    return {
      id2: this.$route.params.id,

      moment: moment,
      data: [ ]
      ,

      loading: false
    };
  },
  computed: {
    pageTitle() {
      return this.data.invoiceId === 0 ? "Nuevo Cliente" : this.data.invoiceId;
    },
    totalRequest(){
      return this.data.reduce((acc,item) => acc + item.total,0 )
    }
  },
  created() {
    let self = this;
    self.getID(this.$route.params.id);
  },
 

  methods: { 
    
    reload(){
          let self = this;
            self.getID(0);
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
            self.getID(0);
          })
          .catch(r => {
            self.$message({
              message: "Ocurrio un error inesperado.",
              type: "error"
            });
          });
      }
    },
   getID(id) {

      let self = this;    
       self.loading = true;
       self.$store.state.services.invoiceDetailService
            .getID(id)
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
}
  }
};
</script>
<template >
<div>
   <h2></h2>
   <a v-bind:href="url"></a>
 <el-table size="small" stripe  :data="data" height="200px"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">
    
        <el-table-column  label="ID" sortable>
           
         <span  v-if="scope.row.invoiceId=== data.id " slot-scope="scope" >
           {{scope.row.invoiceId}}
         </span>
      
         </el-table-column>

       <el-table-column    label="Productos" sortable>
          <span  v-if="scope.row.invoiceId=== id  " slot-scope="scope">
            {{scope.row.invoiceId}}
            </span>
      </el-table-column>
     
      <el-table-column   label="Precio"  sortable>
         <span v-if="scope.row.invoiceId===id " slot-scope="scope" >
           {{scope.row.unitPrice}}
           </span>
      </el-table-column>

  <el-table-column label="Cantidad"   sortable>
          <span v-if="scope.row.invoiceId=== id " slot-scope="scope" >
            {{scope.row.quantity}}
            </span>
      </el-table-column>

  <el-table-column label="Total" sortable>
          <span  v-if="scope.row.invoiceId===id "  slot-scope="scope">
            {{scope.row.total}}
            </span>
      </el-table-column>

    </el-table>
 <a> {{id}}</a>

    </div>

</template>

<script >
var moment = require("moment");
export default {
  name: "InvoiceDetailIndex",
  data() {
    return {
id:this.$route.params.id,
  
      moment:moment,
      data: [
        {
          productId: 0,
          invoiceId: 0,
          quantity: null,
          unitPrice: null,
          total: null
        }
      ],

      /*form: {
      productId:0,
        invoiceId:0,
        quantity:null,
        unitPrice:null,
        total:null
    }*/
      loading: false
    };
  },
  computed: {
    pageTitle() {
      return this.data.invoiceId === 0 ? "Nuevo Cliente" : this.data.invoiceId;
    }
  },
  created() {
    let self = this;
    self.getAll();
  },

  methods: {
 
    getAll() {
      let self = this;
      self.loading = true;
      //if(id == this.form.invoiceId)
      self.$store.state.services.invoiceDetailService

        .getAll()
        .then(r => {
          self.loading = false;
        
          self.data = r.data;
          self.data.invoiceId = r.data.invoiceId;

        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    },/*
    
   get(id) {
 if(id == undefined)return;

      let self = this;    

       self.loading = true;
       self.$store.state.services.invoiceDetailService
            .get(id)
            .then(r => {
              self.loading = false;
              self.form.productId = r.data.productId;
              self.form.quantity = r.data.quantity;
              self.form.unitPrice = r.data.unitPrice;
              self.form.total = r.data.total;
              self.form.invoiceId = r.data.invoiceId;
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });      
   },*/
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
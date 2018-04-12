<template>
<div >


<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading"><h2>Facturas </h2> </div>
  <div   style="margin: 15px 0" class="panel-body">
<el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/invoices/${0}/add`)">Crear Factura </el-button>
  </div>

 <el-table   height="440px" size="small" stripe  v-loading="loading" :data="data"   highlight-current-row @current-change="handleCurrentChange" style="width: 100%">
<br>
      <el-table-column  prop="invoiceId"  label="# Factura" width="100" sortable> </el-table-column>
      <el-table-column prop="invoiceDate" label="Fecha"  sortable>
        <template slot-scope="scope">
            {{moment(scope.row.invoiceDate,moment.ISO_8601).format('L') }}
        </template>
      </el-table-column>
      <el-table-column prop="dueDate"   label="Fecha Limite"  sortable>
           <template slot-scope="scope">
            {{moment(scope.row.dueDate,moment.ISO_8601).format('L') }}
        </template>
      </el-table-column>
      <el-table-column prop="totalAmount"  label="Total"  width="100" sortable></el-table-column>
      <el-table-column prop="amountPaid"  label="Total Pagado"  sortable></el-table-column>
      <el-table-column prop="balanceDue"  label="Total Pendiente"  sortable></el-table-column>
      <el-table-column prop="status"  label="Estado"  sortable></el-table-column>
      <el-table-column fixed="right" width="100">
       <template slot-scope="scope">
        <el-button @click="$router.push(`/invoices/${scope.row.invoiceId}/details`)" type="text" size="small">Detalles</el-button>
      </template>
    </el-table-column>
     
    </el-table>
    </div>
</div>
</template>

<script >
var moment=require('moment');

export default {
   
  name: "InvoiceIndex",
  data() {
    return {
      moment:moment,
      data: [],
      
      loading: false
    };
  },
  created() {
    let self = this;
    self.getAllIV();
    
  }, 
  mounted:function(){
        this.myDate() 
  } ,
  methods: {
    myDate() {
    var str = "2016-02-02T00:00:00"; 
    var res = str.slice(0, 10);
    document.getElementById("demo").innerHTML = res;
},
    getAllIV() {
      let self = this;
      self.loading = true;
      self.$store.state.services.invoiceService
        .getAllIV()
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
  }
};
</script>
<template>
<div >


<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading"><h2>Facturas </h2> </div>
  <div   style="margin: 15px 0" class="panel-body">
<el-button  icon="el-icon-plus"  type="primary"  @click="$router.push(`/invoices/add`)">Crear Factura </el-button>
  </div>
<!--
{{moment("1995-12-25").format('L')}} 
<br>
 {{prop='dueDate'}}
<br>
 {{moment("2016-02-02T00:00:00",moment.ISO_8601).format('L')}}
 <br>
<span>{{ new Date() | moment("dddd, MMMM Do YYYY") }}</span>
{{dateeee}}

<p @onload="myDate()" id="demo"> </p>
<button @click="myDate()">Try it</button>
<p id="demo"> </p>
-->
 <el-table   height="440px" size="small" stripe  v-loading="loading" :data="data"   highlight-current-row @current-change="handleCurrentChange" style="width: 100%">

      <el-table-column fixex="top" prop="invoiceId"  label="# Factura" width="100" sortable> </el-table-column>
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
      <el-table-column prop="notes"  label="Notas"  sortable></el-table-column>
      <el-table-column fixed="right" width="100">
       <template slot-scope="scope">
        <el-button @click="$router.push(`/invoices/${scope.row.invoiceId}/details`)" type="text" size="small">Detail</el-button>
      </template>
    </el-table-column>
     <!--
  <el-table-column align="center">
<template slot-scope="scope" >
<el-button icon="el-icon-edit"  type="warning" title="Editar" @click="$router.push(`/invoices/${scope.row.invoiceId}/edit`)"></el-button>
<el-button  icon="el-icon-delete" type="danger" title="Eliminar" @click="remove(scope.row.invoiceId)">  </el-button>
  </template>
     </el-table-column>
     -->
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
    self.getAll();
    
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
    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.invoiceService
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
            self.$store.state.services.invoiceService
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
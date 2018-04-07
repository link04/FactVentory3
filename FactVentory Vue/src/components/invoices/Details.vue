<template  >
 <div >
   
<div id="printableArea" class="the-div" >

<div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading"><h2>Detalle de Factura </h2> </div>
 
   </div>
  <div class="div-left">
<label   >Vendedor</label>
<br>
<el-tag  size="default" prop="companyId" v-text="form.companyId"> </el-tag>
<hr>

<label >Cliente</label>
<br>
<el-tag  size="default" prop="costumerId" v-text="form.costumerId">  </el-tag>
</div>

<div  class="div-right">
<strong><label ># Factura:</label>
<label v-text="form.invoiceId"  ></label>
</strong>
<br>
<label >Fecha de Factura:</label>
<label v-text="moment(form.invoiceDate,moment.ISO_8601).format('L') "  ></label>
<br>
<label >Fecha Limite:</label>
<label v-text="moment(form.dueDate,moment.ISO_8601).format('L') "  ></label>
</div>

<el-row>
  <index> </index>
</el-row>

 <div >
<div  class="div-left" >
<label   >Notas de Factura</label>
<br>
<el-tag  size="default" prop="notes" v-text="form.notes"> </el-tag>
</div>

<div class="div-right">
<label  >Total a Pagar:</label>
<label v-text="form.totalAmount"  ></label>
<br>
<label >Total Pagado:</label>
<label v-text="form.amountPaid"  ></label>
<br>
<label >Total Pendiente:</label>
<label v-text="form.balanceDue"  > </label>
<hr>
<label >Estado de Factura:</label>
<strong><label v-text="form.status"  ></label></strong>
</div>
 </div>

  <!--<el-table  size="small" stripe  v-loading="loading" :data="data" height="460"  highlight-current-row @current-change="handleCurrentChange" style="width: 100%">
      <el-table-column prop="amountPaid"  label="Total Pagado"  sortable></el-table-column>
      <el-table-column prop="balanceDue"  label="Total Pendiente"  sortable></el-table-column>
      <el-table-column prop="status"  label="Estado"  sortable></el-table-column>
      <el-table-column prop="notes"  label="Notas"  sortable></el-table-column>
      <el-table-column prop="notes"  label="Notas"  sortable></el-table-column>
    
  <el-table-column align="center">
<template slot-scope="scope" >
<el-button icon="el-icon-edit"  type="warning" title="Editar" @click="$router.push(`/invoices/${scope.row.invoiceId}/edit`)"></el-button>
<el-button  icon="el-icon-delete" type="danger" title="Eliminar" @click="remove(scope.row.invoiceId)">  </el-button>
  </template>
     </el-table-column>
    
    </el-table>
     -->

   
</div>
 <div class="bottom-div">
   
<div class="div-left" style="margin-right: 585px;" >
  
<el-button icon="el-icon-printer"  @click="print_pdf()" type="info" >Imprimir</el-button>


<el-button  icon="el-icon-share" type="primary"  @click.prevent="sendemail">Enviar a Cliente</el-button>
</div>

<div class="div-right">
    <el-tooltip class="item" effect="dark" content="Editar" placement="top-start">
<el-button icon="el-icon-edit"  type="warning"  @click="$router.push(`/invoices/${form.invoiceId}/edit`)"></el-button>
    </el-tooltip>
        <el-tooltip class="item" effect="dark" content="Eliminar" placement="top-end">
<el-button  icon="el-icon-delete" type="danger"  @click="remove(form.invoiceId)" >  </el-button>
    </el-tooltip>

</div>

</div>
</div>
</template>

<script>
import index from "@/components/invoiceDetails/Index";

var moment=require('moment');

export default {
  
  components: {
    index
  },
  props: {
    source: String
  }
  ,
  name: "InvoiceDetail",
  name: "CostumerCreateOrUpdate",
  data() {
    return {
      moment:moment,
      loading: false,
      form: {
        invoiceId: 0,
        costumerId:0,
        companyId:0,
       
       invoiceDate:null,
        dueDate: null,
        totalAmount: null,
        amountPaid: null,
        balanceDue: null,

        status: null,
        notes:null,

        costumer:null,
        company:null,

      },
     
      rules: {
        fullName: [
          { required: true, message: "Debe ingresar un nombre" },
          { min: 3, message: "El Nombre debe contener mas de 3 caracteres " }
        ],
        email: [
          { required: true, message: "Debe ingresar un email" },
          { type: "email", message: "Formato de Email incorrecto" }
        ],
        phoneNumber: [
          { required: true, message: "Debe ingresar un telefono" },
          {
            min: 10,
            max: 10,
            message: "El telefono de ser un numero de 10 digitos"
          }
        ],
        address: [{ required: true, message: "Debe por lo menos ingresar la ciudad" }]
      }
    };
  },
  computed: {
    pageTitle() {
      return this.form.costumerId === 0 ? "Nuevo Cliente" : this.form.fullName;
    } 
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
    },
  methods: { 
    print_pdf : function(){
      
 printJS({printable:'printableArea', type:'html', showModal:true,honorMarginPadding:true, maxWidth:1000 ,targetStyle:'*' });
    },
   
 isNumber: function(evt) {
      evt = (evt) ? evt : window.event;
      var charCode = (evt.which) ? evt.which : evt.keyCode;
      if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode !== 46) {
        evt.preventDefault();
      } else {
        return true;
      }
      },
      
    get(id) {
     if(id == undefined)return;

      let self = this;    
  self.loading = true;

       self.$store.state.services.invoiceService
       
            .get(id)
            .then(r => {
              self.loading = false;
              self.form.invoiceId = r.data.invoiceId;
              self.form.costumerId = r.data.costumerId;
              self.form.companyId = r.data.companyId;
              self.form.invoiceDate = r.data.invoiceDate;
              self.form.dueDate = r.data.dueDate;
              self.form.totalAmount = r.data.totalAmount;
              self.form.amountPaid = r.data.amountPaid;
              self.form.balanceDue = r.data.balanceDue;
              self.form.status = r.data.status;
              self.form.notes = r.data.notes;
              self.form.costumer = r.data.costumer;
              self.form.company = r.data.company;
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
      
    },
    
    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
         self.loading = true;

           if(self.form.costumerId > 0 ){
          self.$store.state.services.invoiceService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/invoices');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });
      }else{ 
         
       self.$store.state.services.invoiceService
            .add(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/invoices');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });
      }
        }
      });
    },
}
};
</script>
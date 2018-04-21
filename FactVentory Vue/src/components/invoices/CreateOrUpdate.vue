<template>
<div style="float:top;" >

  <!-- Default panel contents -->
  <div class="panel-heading "><h2>Crear Factura</h2></div>

<div style="background-color:white;padding:20px" >

<el-form id="myForm" v-loading="loading" :model="form" :rules="rules" ref="ruleForm" label-width="60px"  label-position="top" inline="true"  class="demo-ruleForm"> 

           <el-form-item prop="costumer" label="Cliente"  >
     <el-input  type="text" v-model="searchCostumer"  placeholder="Filtrar Cliente a Elegir"></el-input>
     <br>
         <el-select  v-model="form.costumer" >
           <el-option v-bind:key="costumer" v-for="costumer in filteredCostumers" :value="costumer.fullName" >{{costumer.fullName}} </el-option>
        </el-select>
     </el-form-item>
  
 <el-form-item prop="company" label="Vendedor"  >
  <el-input  type="text" v-model="searchEmployee"  placeholder="Filtrar Empleado a Elegir"></el-input>
     <br>
         <el-select  v-model="form.company" >
           <el-option v-bind:key="company" v-for="company in filteredEmployees" :value="company.companyName" >{{company.companyName}} </el-option>
        </el-select>    
         </el-form-item>

  <el-form-item prop="invoiceDate" label="Fecha de Factura"   >
      <el-date-picker type="date" placeholder="Elija su Fecha"   v-model="form.invoiceDate"  style="width: 100%;"  ></el-date-picker>
  </el-form-item>

    <el-form-item prop="dueDate" label="Fecha Limite"  >
      <el-date-picker type="date" placeholder="Elija su Fecha"  v-model="form.dueDate"  style="width: 100%;" ></el-date-picker>
  </el-form-item>

<br>
 <el-form-item>
    <el-button icon="el-icon-plus" @click="show" type="success">Agregar Producto</el-button>
  </el-form-item>
<br>

 <!-- <br>
<el-row>
  <index> </index>
</el-row>
    <br> -->

  <el-form-item label="Notas" prop="notes" >
    <el-input type="textarea" v-model="form.notes" style="width:400px; " placeholder="Ingrese notas de la factura"></el-input>
  </el-form-item>

<el-form-item style="float:right; " >
      <el-form-item prop="totalAmount"   >
        <label>Monto Total</label><br>
    <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"   v-model="form.totalAmount"  disabled>
        </el-form-item> 
      
<br>
      <el-form-item  prop="amountPaid"   >  
          <label>Monto Pagado  </label><br>
          <input class="el-input__inner" style="width:100px;height:30px;"   v-model="form.amountPaid"   >
       </el-form-item>  
 <br>
        <el-form-item prop="balanceDue"  v-model="form.balanceDue" > 
           <label>Balance Pendiente</label><br>
          <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"   disabled  >
       </el-form-item>   
  <br>
        </el-form-item>  
<br>
      <el-form-item  prop="status"  label="Estado">
    <el-radio-group  v-model="form.status" size="medium">
      <el-radio  border label="Pago"></el-radio>
      <el-radio border label="Pendiente"></el-radio>
    </el-radio-group>
      </el-form-item>

<br>
 <el-form-item>
    <el-button icon="el-icon-circle-check-outline" size="medium" @click="saveInvo" type="primary">Crear Factura</el-button>
  </el-form-item>
<br>
</el-form>

<el-button  style="float:left;" size="mini" icon="el-icon-back"  @click="$router.push(`/invoices`)" type="text">Volver a la Lista</el-button>

</div>
<!--Modaaallll----------------------------------------------------------
<modal  name="products"  >
<br>
  <label style="padding:20px;padding-top:20px" >Seleccione Producto</label>
<div id="details" style="padding:40px">

<el-form v-loading="loading" :model="form2" :rules="rules"  ref="ruleForm2" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 
 
 <el-form-item prop="product" label="Producto"   >
      <select v-model="prodToInvi" class="el-input__inner" style="width:248px;height:30px" >
      <option  style="width:248px;height:25px"  v-if="item.quantity > 0" aria-placeholder="Seleccione Producto"
         v-bind:key="item" v-for="item  in productname2" 
      :value="item" >{{item.productName}}</option>
     </select>
 </el-form-item>

  <el-form-item  prop="quantity" label="Cantidad"   >  
          <input class="el-input__inner" type="number" min="1" value="1" :max="this.prodToInvi.quantity"   style="width:248px;height:30px;"  v-model.number="form2.quantity"  >
         </el-form-item>  
         
     <el-form-item prop="unitPrice" label="Precio"  > 
          <input class="el-input__inner" style="width:248px;height:30px;background-color:lightgray;"    v-model.number="form2.unitPrice"  disabled  >
 
     
       </el-form-item>  
<el-form-item prop="total" label="Total" v-model="form2.total" > 
           <input class="el-input__inner" style="width:248px;height:30px;background-color:lightgray;"  v-model.number="form2.total"  :value="Insert()" disabled  >
      
       </el-form-item>    
<br>
 <el-form-item style="float:right" >
    <el-button icon="el-icon-circle-plus" @click="saveID"  type="primary">Agregar</el-button>
     <el-button icon="el-icon-circle-close" @click="hide" type="danger">Cerrar</el-button>
          <el-button @click="clearElements()">Limpiar</el-button>

   </el-form-item>
<br>
</el-form>

</div>
</modal>
-->

</div>
</template>

<script>
//import index from "@/components/invoiceDetails/Index";

export default {
  name: "InvoiceCreateOrUpdate",
  name: "InvoiceDetailIndex",
  /*
  components: {
    index
  },
  props: {
    source: String
  },*/

  data() {
    return {
      loading: false,
      costumers: [],
      searchCostumer:'',
      companies: [],
      searchEmployee:'',
      form: {
        invoiceId: 0,
        costumerId: 0,
        companyId: 0,

        invoiceDate: "",
        dueDate: "",
        totalAmount: 0,
        amountPaid: 0,
        balanceDue: 0,

        status: null,
        notes: null,

        costumer: null,
        company: null
      } /*,
      form2: {
        invoiceDetailId: 0,
        invoiceId: 0,
        productId: 0,
        unitPrice: 0,
        quantity: 1,
        total: 0,
        product: null
      }*/
    };
  },
  computed: {
    pageTitle() {
      return this.form.invoiceId === 0 ? "Nuevo Cliente" : this.form.fullName;
    },
    filteredCostumers:function(){
      return this.costumers.filter((costumer) => {
        return costumer.fullName.match(this.searchCostumer)
      });
    },
    filteredEmployees:function(){
      return this.companies.filter((company) => {
        return company.companyName.match(this.searchEmployee)
      });
    }
  },
  created() {
    let self = this;
    self.getAllCM();
    self.getAllCP();
    self.getInv(self.$route.params.id);

  },
  methods: {
    isNumber: function(evt) {
      evt = evt ? evt : window.event;
      var charCode = evt.which ? evt.which : evt.keyCode;
      if (
        charCode > 31 &&
        (charCode < 48 || charCode > 57) &&
        charCode !== 46
      ) {
        evt.preventDefault();
      } else {
        return true;
      }
    },
    getAllCM() {
      let self = this;
      self.loading = true;
      self.$store.state.services.costumerService
        .getAllCM()
        .then(r => {
          self.loading = false;
          self.costumers = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    }, 
    getAllCP() {
      let self = this;
      self.loading = true;
      self.$store.state.services.companyService
        .getAllCP()
        .then(r => {
          self.loading = false;
          self.companies = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    },
    // getInv(id) {
    //  if(id == undefined)return;

    //   let self = this;

    //    self.loading = true;
    //    self.$store.state.services.invoiceService

    //         .getInv(id)
    //         .then(r => {
    //           self.loading = false;
    //           self.form.invoiceId = r.data.invoiceId;
    //           self.form.costumerId = r.data.costumerId;
    //           self.form.companyId = r.data.companyId;
    //           self.form.invoiceDate = r.data.invoiceDate;
    //           self.form.dueDate = r.data.dueDate;
    //           self.form.totalAmount = r.data.totalAmount;
    //           self.form.amountPaid = r.data.amountPaid;
    //           self.form.balanceDue = r.data.balanceDue;
    //           self.form.status = r.data.status;
    //           self.form.notes = r.data.notes;
    //           self.form.costumer = r.data.costumer;
    //           self.form.company = r.data.company;

    //         })
    //         .catch(r => {
    //           self.$message({
    //             message: "Ocurrio un error inesperado.",
    //             type: "error"
    //           });
    //         });
    // },
    saveInvo() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
          self.loading = true;

          if (self.form.invoiceId > 0) {
            self.$store.state.services.invoiceService
              .update(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push("/invoices");
              })
              .catch(r => {
                self.$message({
                  message: "Ocurrio un error inesperado.",
                  type: "error"
                });
              });
          } else {
            self.$store.state.services.invoiceService
              .addInvo(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push("/invoices");
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
    }
  }
};
</script>
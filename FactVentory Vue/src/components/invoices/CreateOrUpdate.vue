<template>
<div  >

  <!-- Default panel contents -->
  <div class="panel-heading: float:top;padding-top:50px"><h2>Crear Factura</h2></div>

<div style="background-color:white;padding:40px" >

<el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 

     <el-form-item prop="costumer" label="Cliente"  >
      <el-select v-model="form.costumer" >
      <el-option v-bind:key="item" v-for="item in fullname2" :value="item.fullName"></el-option>
     </el-select>
     </el-form-item>

  <el-form-item prop="invoiceDate" label="Fecha de Factura" >
      <el-date-picker type="date" placeholder="Elija su Fecha" v-model="form.invoiceDate" style="width: 100%;"></el-date-picker>
  </el-form-item>

    <el-form-item prop="dueDate" label="Fecha Limite" >
      <el-date-picker type="date" placeholder="Elija su Fecha"  v-model="form.dueDate" style="width: 100%;"></el-date-picker>
  </el-form-item>
<br>
 <el-form-item>
    <el-button icon="el-icon-plus" @click="show" type="success">Agregar Producto</el-button>
  </el-form-item>
<br>
  <el-form-item label="Notas" prop="notes" >
    <el-input type="textarea" v-model="form.notes" style="width:400px; " placeholder="Ingrese notas de la factura"></el-input>
  </el-form-item>

  <el-form-item style="float:right; " >

      <el-form-item prop="totalAmount" >
        <label>Monto Total</label><br>
              <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;" v-model="form.totalAmount" disabled>
        </el-form-item> 
<br>
      <el-form-item  prop="amountPaid" >  
          <label>Monto Pagado  </label><br>
          <input class="el-input__inner" style="width:100px;height:30px;" v-model="form.amountPaid"  v-on:keypress="isNumber(event)">
  </el-form-item>  
 <br>
        <el-form-item prop="balanceDue" > 
           <label>Balance Pendiente</label><br>
          <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;" v-model="form.balanceDue" disabled  >
       </el-form-item>  
<br>
 </el-form-item>  
<br>
        <el-form-item prop="status"  label="Estado">
    <el-radio-group v-model="form.status" size="medium">
      <el-radio border label="Pago"></el-radio>
      <el-radio border label="Pendiente"></el-radio>
    </el-radio-group>
  </el-form-item>

<br>
 <el-form-item>
    <el-button icon="el-icon-circle-check-outline" @click="save" type="primary">Guardar</el-button>
  </el-form-item>
<br>
 
</el-form>
<el-button  style="float:left;" size="mini" icon="el-icon-back"  @click="$router.push(`/invoices`)" type="text">Volver a la Lista</el-button>
 
</div>
<!--Modaaallll------------------------------------------------------------>
<modal name="products">
<el-form v-loading="loading" :model="form2" :rules="rules" ref="ruleForm" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 

     <el-form-item prop="product" label="Seleccione Producto"  size="mini" >
      <select v-model="form2" class="el-input__inner" style="height:30px" >
      <option aria-placeholder="Seleccione Producto" v-bind:key="item" v-for="item in productname2" :value="item" >{{item.productName}}</option>
     </select>
     </el-form-item>
     

       <el-form-item  prop="quantity" label="Cantidad"   >  
          
          <input class="el-input__inner" style="width:100px;height:30px;" v-model="form2.quantity" v-on:keypress="isNumber(event)">
       
  </el-form-item>  

<br>
     <el-form-item prop="unitPrice" label="Precio"  > 
          <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"  
           :value=" form2.unitPrice"  disabled  >

       
       </el-form-item>  

 <el-form-item prop="total" label="Total" v-model="form2.total" > 
          
          <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"   :value="sum()" disabled  >
      <label  :value="form2.total"></label>
       </el-form-item>    

</el-form>

</modal>

</div>
</template>

<script>
export default {
  name: "InvoiceCreateOrUpdate",
  name: "ProductIndex",
  data() {
    return {
      fullname2: [],
   productname2:[],
 
      loading: false,
      form: {
        invoiceId: 0,
        costumerId: 0,
        companyId: 0,

        invoiceDate: null,
        dueDate: null,
        totalAmount: null,
        amountPaid: null,
        balanceDue: null,

        status: null,
        notes: null,

        costumer: null,
        company: null
      },
       form2: {
        invoiceId: 0,
        product:null,
        productId: 0,
        unitPrice: 0,
        quantity: 0,
        total: 0
        
      },
       rules: {
          amountPaid: [
            { required: true, message: 'Inserte monto', trigger: 'blur' },
          ],
          costumer: [
            { required: true, message: 'Por favor seleccione cliente', trigger: 'change' }
          ],
          invoiceDate: [
            { type: 'date', required: true, message: 'Elija Fecha por favor', trigger: 'change' }
          ],
          dueDate: [
            { type: 'date', required: true, message: 'Elija Fecha por favor', trigger: 'change' }
          ],
          status: [
            { required: true, message: 'Por favor seleccion estado ', trigger: 'change' }
          ],
          notes: [
            { required: true, message: 'Por favor digite notas ', trigger: 'blur' }
          ]
        }
      };
  },
  created() {
    let self = this;
    self.getAll();
    self.get(id);
  },
  methods: {
    sum(){
      let total=0;
      total=this.form2.quantity * this.form2.unitPrice
      this.form2.total = total;
      return total;
    },
     show () {
    this.$modal.show('products');
  },
  hide () {
    this.$modal.hide('products');
  },
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
    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.costumerService
        .getAll()
        .then(r => {
          self.loading = false;
          self.fullname2 = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
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
      
    }
    ,
    
        getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.productService
        .getAll()
        .then(r => {
          self.loading = false;
          self.productname2 = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
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
    }
  }
};
</script>
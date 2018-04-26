<template>
<div style="float:top;" >

  <!-- Default panel contents -->
  <div class="panel-heading "><h2>Crear Factura</h2></div>

<div style="background-color:white;padding:20px" >

<el-form id="myForm" v-loading="loading" :model="form" :rules="rules" ref="ruleForm" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 

     <el-form-item prop="costumer" label="Cliente"  >
      <select v-model="costToInvi" class="el-input__inner" style="width:248px;height:28px" >
      <option  v-bind:key="item" v-for="item in fullname2" :value="item">{{item.fullName}}</option>
     </select>
     </el-form-item>

 <el-form-item prop="company" label="Vendedor"  >
      <select v-model="compToInvi" class="el-input__inner" style="width:248px;height:28px" >
      <option v-bind:key="item" v-for="item in fullname3" :value="item">{{item.companyName}}</option>
     </select>
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
 <br>
<el-row>
  <index> </index>
</el-row>
    <br>

  <el-form-item label="Notas" prop="notes" >
    <el-input type="textarea" v-model="form.notes" style="width:400px; " placeholder="Ingrese notas de la factura"></el-input>
  </el-form-item>

<el-form-item style="float:right; " >
      <el-form-item prop="totalAmount"   >
        <label>Monto Total</label><br>
    <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"   v-model="form.totalAmount"  :value="totalRequest()" disabled>
        </el-form-item> 
      
<br>
      <el-form-item  prop="amountPaid"   >  
          <label>Monto Pagado  </label><br>
          <input class="el-input__inner" style="width:100px;height:30px;"   v-model="form.amountPaid" v-on:keypress="isNumber(event)"    >
       </el-form-item>  
 <br>
        <el-form-item prop="balanceDue" > 
           <label>Balance Pendiente</label><br>
          <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"  v-model="form.balanceDue"  disabled  >
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
<!--Modaaallll------------------------------------------------------------>
<modal  name="products"  >
<br>
  <label style="padding:20px;padding-top:20px" >Seleccione Producto</label>
<div id="details" style="padding:40px">

<el-form v-loading="loading" :model="form2" :rules="rules"  ref="form2" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 
 
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


</div>
</template>

<script>
import index from "@/components/invoiceDetails/Index";

export default {

  name: "InvoiceCreateOrUpdate",
  name: "InvoiceDetailIndex",

 components: {
    index
  }
  ,  props: {
    source: String
  },


  data() {
    return {
      fullname3: [],
      fullname2: [],
   productname2:[],
   prodToInvi:[],
    costToInvi:[],
    compToInvi:[],
    data:[],
      form: {
        invoiceId: 0,
        costumerId: 0,
        companyId: 0,

        invoiceDate: Date,
        dueDate: Date,
        totalAmount: 0,
        amountPaid: 0,
        balanceDue: 0,

        status: null,
        notes: null,

        costumer:null,
        company:null

      },
       form2: {

      invoiceDetailId:0,
        invoiceId: 0,
        productId:0,
        unitPrice: 0,
        quantity: 1,
        total: 0,
        product:null

      },   
      loading: false,
       rules: {
          amountPaid: [
            { required: true, message: 'Inserte monto', trigger: 'blur' },
          ],/*
          costumer: [
            { required: true, message: 'Por favor seleccione cliente', trigger: 'change' }
          ],
           company: [
            { required: true, message: 'Por favor seleccione cliente', trigger: 'change' }
          ],*/
          invoiceDate: [
            { type: 'date', required: true, message: 'Elija Fecha por favor', trigger: 'change' }
          ],
          dueDate: [
            { type: 'date', required: true, message: 'Elija Fecha por favor', trigger: 'change' }
          ],
          
           quantity: [
            { required: true, message: 'Por favor ingrese cantidad ', trigger: 'blur' }
          ]
        }
      };
  }, 
  computed: {
   

  },
  created() {
    let self = this;
    self.totalRequest();
    self.getAllCM();
    self.getAllPD();
    self.getAllCP();
    self.getID(this.$route.params.id);

   self.clearElements();
    },
  methods: {
      clearElements() {
    // variable declaration
    var x, y, z, type = null, object = [];
    // collect form elements
    object[0] = document.getElementById('details').getElementsByTagName('input');
    object[1] = document.getElementById('details').getElementsByTagName('textarea');
    object[2] = document.getElementById('details').getElementsByTagName('select');
    // loop through found form elements
    for (x = 0; x < object.length; x++) {
        for (y = 0; y < object[x].length; y++) {
            // define element type
            type = object[x][y].type;
            switch (type) {
            case 'number':
            case 'text':
            case 'textarea':
            case 'password':
               object[x][y].value = '';
                break;
                object[x][y].value = '';
                break;
            case 'radio':
            case 'checkbox':
                object[x][y].checked = '';
                break;
            case 'option':
                object[x][y].options[0].selected = true;
                break;
            case 'select-multiple':
                for (z = 0; z < object[x][y].options.length; z++) {
                    object[x][y].options[z].selected = false;
                }
                break;
            } // end switch
        } // end for y
    } // end for x
},

     resetForm() {
        this.$refs["ruleForm2"].resetFields();


      },
     totalRequest(){
       this.form.company = this.compToInvi.companyName;
       this.form.companyId = this.compToInvi.companyId;
       this.form.costumerId = this.costToInvi.costumerId;
        this.form.costumer = this.costToInvi.fullName;
       let total;
       total = this.data.reduce((acc,item) => acc + item.total,0 )
       this.form.totalAmount = total.toFixed(2);
       let due;
       due = total - this.form.amountPaid;
       if(due < 1 )
       {
         this.form.status = "Pago"
          this.form.balanceDue  = 0 ;
       }else{
       this.form.status = "Pendiente"
      this.form.balanceDue  = due.toFixed(2)
       }
    
       return total;
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
},

    Insert(){
      this.form2.producto = this.prodToInvi.productName;
      this.form2.unitPrice = this.prodToInvi.unitPrice;
      this.form2.productId =  this.prodToInvi.productId;
      let total=0;
      total= this.form2.quantity * this.prodToInvi.unitPrice
      this.form2.total = total.toFixed(2);
      return total.toFixed(2);
    },
    show () {
     this.getAllPD();
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
     getAllCP() {
      let self = this;
      self.loading = true;
      self.$store.state.services.companyService
        .getAllCP()
        .then(r => {
          self.loading = false;
          self.fullname3 = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    },
    getAllCM() {
      let self = this;
      self.loading = true;
      self.$store.state.services.costumerService
        .getAllCM()
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
       getAllPD() {
      let self = this;
      self.loading = true;
      self.$store.state.services.productService
        .getAllPD()
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
    } ,
     getInv(id) {
     if(id == undefined)return;

      let self = this;    
  self.loading = true;

       self.$store.state.services.invoiceService
       
            .getInv(id)
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
              self.form.costumer = r.data.status;
              self.form.producto = r.data.producto;
             
             
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });  
      
    }
    ,saveInvo() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
         self.loading = true;

           if(self.form.invoiceId > 0 ){
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
            .addInvo(self.form)
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
      saveID() {

      let self = this;
    
      self.$refs["form2"].validate(valid => {
        if (valid) {
         self.loading = true;
         
           
           if(self.form2.invoiceDetailId > 0 ){
          self.$store.state.services.invoiceDetailService
            .update(self.form2)
            .then(r => {
              self.loading = false;
               
                  self.$message({
                  type: "success",
                message: "Producto Agregado."
              });
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });
      }else{ 
         
          self.$store.state.services.invoiceDetailService
            .addID(self.form2)
            .then(r => {
             
              self.loading = false;
                this.clearElements()
               this.getID();
                 self.getAllPD();
                

                  self.$message({
            
                   type: "success",
                       message: "Producto Agregado."
              });

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
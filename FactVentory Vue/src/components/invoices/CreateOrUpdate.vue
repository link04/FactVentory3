<template>
<div style="float:top;" >

  <!-- Default panel contents -->
  <div class="panel-heading "><h2>Crear Factura</h2></div>

<div style="background-color:white;padding:20px" >

<el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 

     <el-form-item prop="costumer" label="Cliente"  >
      <select v-model="costToInvi" class="el-input__inner" style="width:248px;height:28px" >
      <option v-bind:key="item" v-for="item in fullname2" :value="item">{{item.fullName}}</option>
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

   <!--  
   <table style="height:180px;" class="el-table el-table--fit el-table--striped el-table--enable-row-hover el-table--enable-row-transition el-table--small">
    
  <tr  >
   
    <th class="col"> Producto</th>
       <th class="col"> Cantidad</th>
     <th class="col"> Precio</th>
       <th class="col"> Total</th>
        <th class="col"> </th>
          
        </tr>
   
    <tr  v-bind:key="item" v-for="item in data" >
      
       <td v-show="item.invoiceId  === null" >{{ item.productId }}</td>
       <td v-show="item.invoiceId  === null" >{{ item.quantity }}</td>
       <td v-show="item.invoiceId  === null" >{{ item.unitPrice }}</td>
       <td v-show="item.invoiceId  === null" >{{ item.total }}</td>
       <td v-show="item.invoiceId  === null">   
      <el-tooltip class="item" effect="dark" content="Eliminar" placement="top-start">
     <button  class="el-button el-tooltip item el-button--danger" 
     @click="remove(item.invoiceDetailId)"> <i class="el-icon-delete"></i></button>
       </el-tooltip>
      </td>
   </tr>
</table>
-->
<el-row>
  <index> </index>
</el-row>
    <br>

  <el-form-item label="Notas" prop="notes" >
    <el-input type="textarea" v-model="form.notes" style="width:400px; " placeholder="Ingrese notas de la factura"></el-input>
  </el-form-item>
  <el-form-item style="float:right; " >
      <el-form-item prop="totalAmount" >
        <label>Monto Total</label><br>
    <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;"  v-model="form.totalAmount" :value="totalRequest()" disabled>
       
        </el-form-item> 
<br>
      <el-form-item  prop="amountPaid" >  
          <label>Monto Pagado  </label><br>
          <input class="el-input__inner" style="width:100px;height:30px;" v-model="form.amountPaid"  >
       </el-form-item>  
 <br>
        <el-form-item prop="balanceDue" > 
           <label>Balance Pendiente</label><br>
          <input class="el-input__inner" style="width:100px;height:30px;background-color:lightgray;" v-model="form.balanceDue" disabled  >
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
    <el-button icon="el-icon-circle-check-outline" @click="saveInvo" type="primary">Guardar</el-button>
  </el-form-item>
<br>
</el-form>

<el-button  style="float:left;" size="mini" icon="el-icon-back"  @click="$router.push(`/invoices`)" type="text">Volver a la Lista</el-button>

</div>
<!--Modaaallll------------------------------------------------------------>
<modal  name="products"  >
<br>
  <label style="padding:20px;padding-top:20px" >Seleccione Producto</label>
<div style="padding:40px">

<el-form v-loading="loading" :model="form2" :rules="rules"  ref="ruleForm2" label-width="60px"  label-position="top" inline="true" size="mini" class="demo-ruleForm"> 
 
 <el-form-item prop="product" label="Producto"   >
      <select v-model="prodToInvi" class="el-input__inner" style="width:248px;height:30px" >
      <option  style="width:248px;height:25px"  v-if="item.quantity > 0" aria-placeholder="Seleccione Producto"
         v-bind:key="item" v-for="item  in productname2" 
      :value="item" >{{item.productName}}</option>
     </select>
 </el-form-item>

  <el-form-item  prop="quantity" label="Cantidad"   >  
          <input class="el-input__inner" type="number" min="1" :max="this.prodToInvi.quantity" style="width:248px;height:30px;" v-model.number="form2.quantity"  >
         </el-form-item>  
     <el-form-item prop="unitPrice" label="Precio"  > 
          <input class="el-input__inner" style="width:248px;height:30px;background-color:lightgray;"  v-model.number="form2.unitPrice"  disabled  >
 
     
       </el-form-item>  
<el-form-item prop="total" label="Total" v-model="form2.total" > 
           <input class="el-input__inner" style="width:248px;height:30px;background-color:lightgray;"  v-model.number="form2.total"  :value="Insert()" disabled  >
      
       </el-form-item>    
<br>
 <el-form-item style="float:right" >
    <el-button icon="el-icon-circle-plus" @click="saveID"  type="primary">Agregar</el-button>
     <el-button icon="el-icon-circle-close" @click="hide" type="danger">Cerrar</el-button>
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
  ,


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
        notes: null
      },
       form2: {

      invoiceDetailId:0,
        invoiceId: 0,
        productId:0,
        unitPrice: 0,
        quantity: '',
        total: 0,

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
    self.getAllCM();
    self.getAllPD();
    self.getAllCP();
    self.getID(this.$route.params.id);
  
  },
  methods: {
     totalRequest(){
       this.form.companyId = this.compToInvi.companyId;
       this.form.costumerId = this.costToInvi.costumerId;
       let total;
       total = this.data.reduce((acc,item) => acc + item.total,0 )
       this.form.totalAmount = total;
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
      this.form2.unitPrice = this.prodToInvi.unitPrice;
      this.form2.productId =  this.prodToInvi.productId;
      let total=0;
      total=this.form2.quantity * this.prodToInvi.unitPrice
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
            .addID(self.form2.invoiceId = self.form.invoiceId )
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
    

      self.$refs["ruleForm2"].validate(valid => {
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
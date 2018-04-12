<template>
<div class="panel panel-default">
  <div class="panel-heading"><h2>Dashboard</h2></div>
  <br>
  

<div  class="dash" style="background-color:#F56C6C;"  @click="$router.push(`/costumers/`)">

  <div style=" position: absolute;padding-left:13px">
  <h2 > {{costumer.length}}</h2>
  <p >Total de Clientes </p>
  </div>  
  <img src="src\assets\user++.png" style=" float:right; width:100px;" />

<div class="dashMe" style="background-color:rgb(247, 71, 71);"  >
 <small>Mas Informacion <i class="el-icon-d-arrow-right"></i> </small> 
</div>
</div>

<div  class="dash" style="background-color:#67C23A;"  @click="$router.push(`/products/`)">

 <div style=" position: absolute;padding-left:13px">
  <h2 > {{product.length}}</h2> 

  <p >Nuevos Productos </p>
  </div>  
  
  <img src="src\assets\726065_label_512x512.png" style=" float:right; width:100px;" />

<div class="dashMe"  style="background-color: rgb(74, 185, 19)" >
 <small>Mas Informacion <i class="el-icon-d-arrow-right"></i> </small> 
</div>
</div>

<div  class="dash"  style="background-color: #E6A23C;"  @click="$router.push(`/salesPersons/`)">
  <div style=" position: absolute;padding-left:13px">
 <h2 > {{salesPerson.length}}</h2> 
   <p >Total de Vendedores </p>
  </div>  
  <img src="src\assets\807476_commerce_512x512.png" style=" float:right; width:100px;" />
<div class="dashMe"  style="background-color: rgb(233, 154, 35)" >
 <small>Mas Informacion <i class="el-icon-d-arrow-right"></i> </small> 
</div>
</div>

<div  class="dash"  style="background-color: #409EFF;"  @click="$router.push(`/invoices/`)">
  <div style=" position: absolute;padding-left:13px">
  <h2 > {{invoice.length}}</h2> 
   <p >Nuevas Facturas </p>
  </div>  

    <img src="src\assets\644141_commerce_512x512.png" style=" float:right; top: 50px;
  left: 50px; width:85px;" />
<div class="dashMe"  style="background-color:rgb(36, 144, 253)" >
 <small>Mas Informacion <i class="el-icon-d-arrow-right"></i> </small> 
</div>
</div>

  <!--
<div> 
   <el-carousel  style=" float:center"  :interval="5000" arrow="always">
    <el-carousel-item  v-for="item in pictures" :value="item" :key="item">
       <div
       transition="fade"
       >
    <img
         :src="pictures[Math.abs(currentNumber) % pictures.length]"
     
         />
  </div>
    </el-carousel-item>
  </el-carousel>

</div>-->
   
  </div>
</template>

<script>
export default {
  name: 'Default',
  data(){
      
  return{
      product:[],
    costumer:[],
    salesPerson:[],
    invoice:[],
 pictures:[
   'https://i.imgur.com/qoDOaPf.png','https://imgur.com/a/CZYvj', 
   'http://i.imgur.com/Lfv18Sb.jpg', 'http://i.imgur.com/tmVJtna.jpg',
   'http://i.imgur.com/ZfFAkWZ.jpg'],
    
  
    };
  },
  created() {
    let self = this;
    self.getAllCM();
    self.getAllPD();
    self.getAllCP();
    self.getAllIV();
  },
  methods: {
    getAllCM() {
      let self = this;
      self.loading = true;
      self.$store.state.services.costumerService
        .getAllCM()
        .then(r => {
          self.loading = false;
          self.costumer= r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    },

   getAllPD(){
      let self = this;
      self.loading = true;
      self.$store.state.services.productService
        .getAllPD()
        .then(r => {
          self.loading = false;
          self.product = r.data;
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
          self.salesPerson = r.data;
        })
        .catch(r => {
          self.$message({
            message: "Ocurrio un error inesperado.",
            type: "error"
          });
        });
    },
     getAllIV() {
      let self = this;
      self.loading = true;
      self.$store.state.services.invoiceService
        .getAllIV()
        .then(r => {
          self.loading = false;
          self.invoice = r.data;
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
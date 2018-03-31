<template>
<div>
<h2>{{pageTitle}} </h2>

<div style="background-color:white; padding:3%">

<el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm" label-width="90px"  class="demo-ruleForm">
  
  <el-form-item label="Producto" prop="productName">
    <el-input v-model="form.productName" style="width:900px" ></el-input>
  </el-form-item>

  <el-form-item label="Precio" prop="unitPrice" >
     <input class="el-input__inner" style="width:900px" v-model="form.unitPrice"  v-on:keypress="isNumber(event)">
  </el-form-item>

  <el-form-item label="Cantidad" prop="quantity">
      <input class="el-input__inner" style="width:900px" v-model="form.quantity"  v-on:keypress="isNumber(event)">
  </el-form-item>

  <el-form-item label="Descripcion"  prop="description">
    <el-input v-model="form.description" style="width:900px"></el-input>
  </el-form-item>

 <el-form-item>
    <el-button icon="el-icon-circle-check-outline" @click="save" type="primary">Guardar</el-button>
  </el-form-item>

 <el-button  style="float:left;" size="small" icon="el-icon-arrow-left"  @click="$router.push(`/products`)" type="text">Volver a la Lista</el-button>
 
</el-form>

  
 <br/>
</div>

</div>
</template>

<script>
export default {
  name: "ProductCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        productId: 0,
        productName: null,
        unitPrice: null,
        quantity: null,
        description: null
      },
      rules: {
        productName: [
          { required: true, message: "Debe ingresar un nombre" },
          { min: 3, message: "El Nombre debe contener mas de 3 caracteres " }
        ],
        unitPrice: [
           { required: true, message: "Debe ingresar el precio en numeros" },,
        ],
        quantity: [
          { required: true, message: "Debe ingresarla cantidad disponible" },
          
        ],
      }
    };
  },
  computed: {
    pageTitle() {
      return this.form.productId === 0 ? "Nuevo Producto" : "Editar Producto";
    } 
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
    },
  methods: {
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
       self.$store.state.services.productService
            .get(id)
            .then(r => {
              self.loading = false;
              self.form.productId = r.data.productId;
              self.form.productName = r.data.productName;
              self.form.quantity  = r.data.quantity;
              self.form.unitPrice = r.data.unitPrice;
              self.form.description = r.data.description;
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

           if(self.form.productId > 0 ){
          self.$store.state.services.productService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/products');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });
      }else{ 
         
          self.$store.state.services.productService
            .add(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/products');
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
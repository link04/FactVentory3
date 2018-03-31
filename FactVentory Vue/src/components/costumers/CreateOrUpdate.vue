<template>
<div>
<h2>{{pageTitle}} </h2>

<el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm" label-width="90px"  class="demo-ruleForm">
  
  <el-form-item label="Nombre" prop="fullName">
    <el-input v-model="form.fullName" style="width:900px" ></el-input>
  </el-form-item>

  <el-form-item label="Email" prop="email" >
    <el-input v-model="form.email" style="width:900px" ></el-input>
  </el-form-item>

  <el-form-item label="Telefono" prop="phoneNumber">
          <input class="el-input__inner" style="width:900px" v-model="form.phoneNumber"  v-on:keypress="isNumber(event)">
 
  </el-form-item>

  <el-form-item label="Direccion"  prop="address">
    <el-input v-model="form.address" style="width:900px"></el-input>
  </el-form-item>

 <el-form-item>
    <el-button icon="el-icon-circle-check-outline" @click="save" type="primary">Guardar</el-button>
  </el-form-item>

 <el-button  style="float:left;" size="small" icon="el-icon-back"  @click="$router.push(`/costumers`)" type="text">Volver a la Lista</el-button>
 
</el-form>

  
 <br/>


</div>
</template>

<script>
export default {
  name: "CostumerCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        costumerId: 0,
        fullName: null,
        email: null,
        phoneNumber: null,
        address: null
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
       self.$store.state.services.costumerService
            .get(id)
            .then(r => {
              self.loading = false;
              self.form.costumerId = r.data.costumerId;
              self.form.fullName = r.data.fullName;
              self.form.email = r.data.email;
              self.form.phoneNumber = r.data.phoneNumber;
              self.form.address = r.data.address;
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
          self.$store.state.services.costumerService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/costumers');
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado.",
                type: "error"
              });
            });
      }else{ 
         
          self.$store.state.services.costumerService
            .add(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/costumers');
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
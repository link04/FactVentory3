<template>
<div>
<div id="app">
  <label><input type="checkbox" v-model="showBlankFruits">Show Blank Fruits</label>
  <br> <br>
  <table>
    <tr> 
    <th class="col">User</th>
    <th class="col">Fruits</th> 
    <th class="col"></th> </tr>
    <tr v-for="item in mylist" v-show="item.fruits.length || showBlankFruits">
      <td>{{ item.user }}</td>
      <td> 
      <span v-for="f in item.fruits"> 
      {{ f.name }} 
      </span>
      </td>
    </tr>
  </table>
</div>


</div>
</template>

<script>
new Vue({
  el: '#app',
  data: {
  	showBlankFruits: true,
    mylist: [
    	{'user': 'Alice', 'fruits': [{'name': 'apple'}]},
    	{'user': 'Bob', 'fruits': [{'name': 'orange'}]},
    	{'user': 'Charlie', 'fruits': []},
    	{'user': 'Denise', 'fruits': [{'name': 'apple'}, {'name': 'orange'}]},
    ]
  },
  methods:{ 
  	delItem: function(item) {
        let index = this.mylist.indexOf(item);
        if (index > -1) {
        	this.mylist.splice(index, 1);
        }
    }
  }
})
</script>
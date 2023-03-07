<template>
  <div class="q-pa-md">
    <div class="text-center">
    <h3>Add Product</h3>
    </div>
    <div class="row">
      <div class="col-6 q-pa-md">
    <q-form
      @submit="add_product"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="addProduct.productName"
        label="Product Name"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />

      <q-input
        filled
        v-model="addProduct.description"
        label="Description"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />

      <q-input
        filled
        type="number"
        v-model="addProduct.price"
        label="Price"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />

      <q-input
        filled
        type="number"
        v-model="addProduct.quantity"
        label="Quantity"
        lazy-rules
        :rules="[
          val => val !== null && val !== '' || 'Please type your age',
          val => val > 0 && val < 100 || 'Please type a real age'
        ]"
      />
      <div>
        <q-btn label="Submit" type="submit" color="primary"/>
        <!-- <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" /> -->
      </div>
    </q-form>
    </div>
    <div class="col-6 q-pa-md">
      <table>
      <thead>
        <tr>
          <th>Product</th>
          <th>Description</th>
          <th>Price</th>
          <th>Quantity in stock</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(product,index) in products" :key="index">
          <td>{{ product.productName }}</td>
          <td>{{ product.description }}</td>
          <td>{{ product.price }}</td>
          <td>{{ product.quintityInStock }}</td>
        </tr>
      </tbody>
    </table>
      <!-- <h4>table</h4>
      <q-card flat bordered class="my-card">
      <q-card-section>
        <div class="text-h5 text-center">{{product.productName}}</div>
      </q-card-section>
      <q-separator inset />

      <q-card-section class="q-pt-none">
        <div class="text-h6">Description</div>
       {{product.description}}
      </q-card-section>

      <q-card-section>
        <div class="text-h6">Price</div>
        {{product.price}}
      </q-card-section>

      <q-card-section>
        <div class="text-h6">Quantity in stock</div>
        {{product.quintityInStock}}
      </q-card-section>
    </q-card> -->
    </div>
</div>
  </div>
</template>

<script>
import { defineComponent } from 'vue'
import axios from 'axios'

export default defineComponent({
  name: 'IndexPage',
   data() {
    return {
      products: null,
      error: null,
      addProduct:{
        productName:null,
        description:null,
        price:null,
        quantity:null
      }
    }
  },
  methods:{
    async add_product () {
      try {
        const addingProducts = {
          productName: this.addProduct.productName,
          description: this.addProduct.description,
          price: this.addProduct.price,
          quintityInStock: this.addProduct.quantity
        }

          console.log('clicked',this.addProduct)
        const response = await axios.post('https://localhost:7187/api/Product/SaveProduct',
          addingProducts
        )
        if (response.statusCode === 200) {
          if (response.data.token === '') {
            this.$q.notify({
              type: 'negative',
              message: 'Check your inputs'
            })
            return
          }

          this.$q.notify({
            type: 'positive',
            message: 'Successfully added a product '
          })
        } else {
          this.$q.notify({
            type: 'negative',
            message: 'error'
          })
        }
      } catch (e) {
      }
    }
  },
 async mounted() {
    const response = await axios.get('https://localhost:7187/api/Product/GetAllProduct')  
        this.products = response.data;
  },
  async created(){

  }
})
</script>

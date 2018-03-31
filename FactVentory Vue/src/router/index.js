import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'

import CostumerIndex from '@/components/costumers/Index'
import CostumerCreateOrUpdate from '@/components/costumers/CreateOrUpdate'

import ProductIndex from '@/components/products/Index'
import ProductCreateOrUpdate from '@/components/products/CreateOrUpdate'

import CompanyIndex from '@/components/companies/Index'
import CompanyCreateOrUpdate from '@/components/companies/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },
  { path: '/costumers/', name: 'CostumerIndex', component: CostumerIndex },
  { path: '/costumers/add', name: 'CostumerCreate', component: CostumerCreateOrUpdate },
  { path: '/costumers/:id/edit', name: 'CostumerEdit', component: CostumerCreateOrUpdate },
  { path: '/products/', name: 'ProductIndex', component: ProductIndex },
  { path: '/products/add', name: 'ProductCreate', component: ProductCreateOrUpdate },
  { path: '/products/:id/edit', name: 'ProductEdit', component: ProductCreateOrUpdate },

  { path: '/companies/', name: 'CompanyIndex', component: CompanyIndex },
  { path: '/companies/add', name: 'CompanyCreate', component: CompanyCreateOrUpdate },
  { path: '/companies/:id/edit', name: 'CompanyEdit', component: CompanyCreateOrUpdate },
]

export default new Router({
  routes
})









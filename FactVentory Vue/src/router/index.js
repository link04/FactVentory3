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

import InvoiceIndex from '@/components/invoices/Index'
import InvoiceDetails from '@/components/invoices/Details'
import InvoiceCreateOrUpdate from '@/components/invoices/CreateOrUpdate'

//import InvoiceDetailIndex from '@/components/invoiceDetails/Index'

//import InvoiceDetailCreateOrUpdate from '@/components/invoiceDetails/CreateOrUpdate'


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
  { path: '/salesPersons/', name: 'CompanyIndex', component: CompanyIndex },
  { path: '/salesPersons/add', name: 'CompanyCreate', component: CompanyCreateOrUpdate },
  { path: '/salesPersons/:id/edit', name: 'CompanyEdit', component: CompanyCreateOrUpdate },

  { path: '/invoices/', name: 'InvoiceIndex', component: InvoiceIndex },
  { path: '/invoices/:id/details', name: 'InvoiceDetails', component: InvoiceDetails },
  { path: '/invoices/add', name: 'InvoiceCreate', component: InvoiceCreateOrUpdate },
  { path: '/invoices/:id/edit', name: 'InvoiceEdit', component: InvoiceCreateOrUpdate },

  //{ path: '/invoiceDetails/:id/details', name: 'InvoiceDetailsIndex', component: InvoiceDetailIndex },

  //{ path: '/invoiceDetails/add', name: 'InvoiceDetailsCreate', component: InvoiceDetailCreateOrUpdate },
  //{ path: '/invoiceDetails/:id/edit', name: 'InvoiceDetailsEdit', component: InvoiceDetailCreateOrUpdate },
]

export default new Router({
  routes
})









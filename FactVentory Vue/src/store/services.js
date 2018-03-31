import Axios from 'axios'
import exampleService from '../services/ExampleService'
import costumerService from '../services/CostumerService'
import productService from '../services/ProductService'
import companyService from '../services/CompanyService'

let apiUrl = 'http://localhost:53650/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService: new exampleService(Axios),
    costumerService: new costumerService(Axios,apiUrl),
    productService: new productService(Axios,apiUrl),
    companyService: new companyService(Axios,apiUrl)
}
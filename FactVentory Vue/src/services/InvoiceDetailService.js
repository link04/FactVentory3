class InvoiceDetailService {
    axios
    baseUrl

    constructor(axios,apiUrl) {
        this.axios = axios
        this.baseUrl = `${apiUrl}invoiceDetail`    
    }

    getID(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/${id}`);
    }
    getAllID() {
        let self = this;
        return self.axios.get(`${self.baseUrl}`);
    }

    addID(model) {
        let self = this;
        return self.axios.post(`${self.baseUrl}`, model);
    }
    
    update(model) {
        let self = this;
        return self.axios.put(`${self.baseUrl}`, model);
    }
    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }

}
export default InvoiceDetailService
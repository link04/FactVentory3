import Vue from 'vue'
import Vuex from 'Vuex'
import moment from 'moment'
import services from './services'


Vue.use(Vuex)
Vue.use(moment)


const state = {
    services
}

export default new Vuex.Store({
    state
})



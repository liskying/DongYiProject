import Vue from 'vue'
import Router from 'vue-router'
import table1 from '@/components/tables/table1'
import table5 from '@/components/tables/table5'

Vue.use(Router)

export default new Router({
    routes: [{
        path: '/',
        name: 'table1',
        component: table1
    }, {
        path: '/',
        name: 'table5',
        component: table5
    }]
})
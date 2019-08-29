import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    userKeeps: [],
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {},
        state.keeps = [],
        state.vaults = [],
        state.userKeeps = []
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    //#region -- Keeps
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps")
        commit('setKeeps', res.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user")
        commit('setUserKeeps', res.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    addKeep({ commit, dispatch }, keepData) {
      api.post('keeps', keepData)
      dispatch('getkeeps')
    },
    //#endregion
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults/user")
        commit('setVaults', res.data)
      } catch (e) {
        console.warn(e.message)
      }
    }
  }
})

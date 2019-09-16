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
    activeKeep: {},
    userKeeps: [],
    vaults: [],
    activeVault: {},
    vaultKeeps: []

  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setActiveVault(state, activeVault) {
      state.activeVault = activeVault
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
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
    async getKeepById({ commit, dispatch }, id) {
      try {
        let res = await api.get("keeps/" + id)
        commit('setActiveKeep', res.data)
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
    async addKeep({ commit, dispatch }, keepData) {
      try {
        await api.post('keeps', keepData)
        dispatch('getKeeps')
        dispatch('getVaults')
        dispatch('getUserKeeps')
      } catch (e) {
        console.warn(e.message)
      }
    },
    async deleteKeep({ commit, dispatch }, keepData) {
      try {
        await api.delete('keeps/' + keepData)
        dispatch('getKeeps')
        dispatch('getVaults')
        dispatch('getUserKeeps')
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults/user")
        commit('setVaults', res.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async addVault({ commit, dispatch }, vaultData) {
      try {
        await api.post('vaults', vaultData)
        dispatch('getKeeps')
        dispatch('getVaults')
        dispatch('getUserKeeps')
      } catch (e) {
        console.warn(e.message)
      }
    },
    async deleteVault({ commit, dispatch }, vaultData) {
      try {
        await api.delete('vaults/' + vaultData)
        dispatch('getKeeps')
        dispatch('getVaults')
        dispatch('getUserKeeps')
      } catch (e) {
        console.warn(e.message)
      }
    },
    async addKeepToVault({ commit, dispatch }, vk) {
      try {
        await api.post('vaultkeeps/', vk)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async getVaultKeeps({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get('vaultkeeps/' + vaultId)
        commit('setVaultKeeps', res.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async deleteVaultKeep({ commit, dispatch }, vaultId) {
      try {
        await api.put('vaults/' + vaultId) // FIXME Add the keep id as well
        dispatch('getVaultKeeps')
      } catch (e) {
        console.warn(e.message)
      }
    },
  }
})

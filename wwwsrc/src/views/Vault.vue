<template>
  <div class="vault">
    <h1>Welcome to Vault {{vault.name}}</h1>

    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <router-link :to="{name: 'dashboard'}">Dashboard</router-link>
    <div class="container flex">
      <div class="row">
        <h4 class="col-12">{{vault.name}} Keeps</h4>
      </div>
      <div class="row">
        <div v-for="keep in vaultKeeps" :keep="keep" class="col-4
        ">
          <p>{{keep.name}}</p>
          <p>{{keep.description}}</p>
          <button type="submit" @click='deleteVaultKeep(keep.id)'>Delete Keep</button>
        </div>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
  import KeepsComponent from '../Components/KeepsComponent.vue'
  export default {
    name: "vault",
    props: ['vaultId'],
    mounted() {
      this.$store.dispatch("getVaultKeeps", this.vaultId)
    },
    data() {
      return {
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps;
      },
      vault() {
        //REVIEW  find the vault where the this.vaultId is 
        return this.$store.state.activeVault
      }
    },
    methods: {
      //   deleteVaultKeep(keep.id) {
      // var vaultKeepDelete = {
      //   vaultId: id,
      //   keepId: t
      // }
      // return this.$store.dispatch('deleteVaultKeep', { id, })
    },
    logout() {
      this.$store.dispatch("logout");
    },
    components: {
      KeepsComponent,
    }
  };
</script>
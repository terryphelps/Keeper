<template>
  <div class="onekeep">
    <h1>Welcome to {{activeKeep.name}} Keep:</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <router-link class="m-1" :to="{name: 'dashboard'}">Dashboard</router-link>
    <!-- <div class="container-fluid"> -->
    <div class="row">
      <h4 class="col">Keep</h4>
    </div>
    <div class="row">
      <div class="col">
        <p>{{activeKeep.name}}</p>
        <p> {{activeKeep.description}}</p>
        <img :src="activeKeep.img" class="image-fluid">
      </div>
    </div>
    <form class="list">
      Select vault to move keep to:
      <select v-model="activeVault">
        <option v-for="vault in vaults" :value="vault">{{vault.name}}</option>
        <!-- v-for="vault in vaults" :vault="vault" -->
      </select>
      <button class="m-1" type="button" @click="addKeepToVault()">Move to Vault</button>
    </form>
  </div>
  <!-- </div> -->
  </div>
</template>

<script>
  import KeepsComponent from '../Components/KeepsComponent.vue'
  export default {
    name: "onekeep",
    props: ['keepId'],
    mounted() {
      this.$store.dispatch("getKeepById", this.keepId)
      this.$store.dispatch("getVaults")
    },
    data() {
      return {
        activeVault: {}
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      activeKeep() {
        return this.$store.state.activeKeep;
      },
      vaults() {
        return this.$store.state.vaults;
      }

    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      addKeepToVault() {
        //REVIEW   CREATE A VAULTKEEP
        var vk = {
          vaultId: this.activeVault.id,
          keepId: this.activeKeep.id,
        }
        this.$store.dispatch("addKeepToVault", vk)
      }
    },
    components: {
      KeepsComponent,
    }
  };
</script>
<style>
  /* .onekeep {
    background-color: beige;
  } */

  .list {
    justify-content: center;
  }
</style>
<template>
  <div class="dashboard container">
    <h1>Welcome to {{user.username}}'s Dashboard</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <router-link class="m-1" :to="{name: 'home'}">Home</router-link>
    <div class="row keeps">
      <h4 class="text-center col">Public Keeps</h4>
    </div>
    <div class="row keeps">
      <KeepsComponent v-for="keep in keeps" :keep="keep"></KeepsComponent>
    </div>
    <div class="row vaults">
      <h4 class="text-center col">User Vaults</h4>
    </div>
    <div class="row vaults">
      <form class="formData text-center col" @submit.prevent="addVault">
        <input type="text" placeholder="name" v-model="newVault.name" required>
        <input type="text" placeholder="description" v-model="newVault.description" required>
        <button type="submit" class="m-1">Add Vault</button>
      </form>
    </div>
    <div class="row vaults">
      <VaultComponent v-for="vault in vaults" :vault="vault"></VaultComponent>
    </div>
    <div class="row ukeeps">
      <h4 class="text-center col">User Keeps</h4>
    </div>
    <div class="row ukeeps">
      <form class="formData text-center col" @submit.prevent="addKeep">
        <input type="text" placeholder="name" v-model="newKeep.name" required>
        <input type="text" placeholder="description" v-model="newKeep.description" required>
        <input type="text" placeholder="img" v-model="newKeep.img">
        <div>
          <input type="checkbox" v-model="newKeep.isPrivate">
          <label for="checkbox">Private </label>
          <button class="m-1" type="submit">Add Keep</button>
        </div>
      </form>
    </div>
    <div class="row ukeeps">
      <UserKeepsComponent v-for="ukeep in userKeeps" :ukeep="ukeep"></UserKeepsComponent>
    </div>
  </div>
</template>

<script>
  import VaultComponent from '../Components/VaultComponent.vue'
  import KeepsComponent from '../Components/KeepsComponent.vue'
  import UserKeepsComponent from '../Components/UserKeepsComponent.vue'
  export default {
    name: "dashboard",
    mounted() {
      this.$store.dispatch("getKeeps")
      this.$store.dispatch("getVaults")
      this.$store.dispatch("getUserKeeps")
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: " ",
          isPrivate: 0
        },
        newVault: {
          name: "",
          description: "",
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      userKeeps() {
        return this.$store.state.userKeeps;
      },
      vaults() {
        return this.$store.state.vaults;
      }
    },
    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.newKeep);
        this.newKeep = { name: "", description: "" };
      },
      addVault() {
        this.$store.dispatch("addVault", this.newVault);
        this.newVault = { name: "", description: "" };
      },
      logout() {
        this.$store.dispatch("logout");
      }
    },
    components: {
      KeepsComponent,
      VaultComponent,
      UserKeepsComponent
    }
  };
</script>
<style scoped>
  .dashboard {
    background-color: beige;
  }

  .keeps {
    background-color: rgb(248, 248, 198);
  }

  .vaults {
    background-color: rgb(248, 248, 131);
  }

  .ukeeps {
    background-color: rgb(248, 248, 198);
  }
</style>
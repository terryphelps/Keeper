<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <div class="container flex">
      <div class="row">
        <h4 class="col-12">Public Keeps</h4>
        <KeepsComponent v-for="keep in keeps" :keep="keep"></KeepsComponent>
      </div>
      <div class="row">
        <h4 class="col-12">User Vaults</h4>
        <VaultComponent v-for="vault in vaults" :vault="vault"></VaultComponent>
      </div>
      <div class="row">
        <h4 class="col-12">User Keeps</h4>
        <form class="formData" @submit.prevent="addKeep">
          <input type="text" placeholder="name" v-model="newKeep.name" required>
          <input type="text" placeholder="description" v-model="newKeep.description" required>
          <input type="text" placeholder="img" v-model="newKeep.img">
          <div>
            <input type="checkbox" v-model="newKeep.isPivate">
            <label for="checkbox">Private</label>
          </div>
          <button type="submit">Add Keep</button>
        </form>
        <UserKeepsComponent v-for="ukeep in userKeeps" :ukeep="ukeep"></UserKeepsComponent>
      </div>
    </div>
  </div>
</template>

<script>
  import VaultComponent from '../Components/VaultComponent.vue'
  import KeepsComponent from '../Components/KeepsComponent.vue'
  import UserKeepsComponent from '../Components/UserKeepsComponent.vue'
  export default {
    name: "home",
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
          img: "",
          isPrivate: ""
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
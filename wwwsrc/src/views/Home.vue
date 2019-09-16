<template>
  <div class="home container">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <router-link class="m-1" :to="{name: 'dashboard'}">Dashboard</router-link>
    <div class="row">
      <h4 class="text-center col">Public Keeps</h4>
    </div>
    <div class="row">
      <KeepsComponent v-for="keep in keeps" :keep="keep"></KeepsComponent>
    </div>
  </div>
</template>

<script>
  import KeepsComponent from '../Components/KeepsComponent.vue'
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getKeeps")
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: " ",
          isPrivate: 0
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
    }
  };
</script>
<style>
</style>
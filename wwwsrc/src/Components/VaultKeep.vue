<template>
  <div class="keeps col-3 border">
    <div class="card">
      <p>{{keep.name}}</p>
      <!-- <router-link :to="{name: 'keeps', params: {keepId: keep.id}}">{{keep.name}}</router-link> -->
      <p>{{keep.description}}</p>
      <button v-if="user.id" type="submit" @click='deleteVaultKeep(vault.id)'>Delete Keep</button>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keeps",
    mounted() {
    },
    data() {
      return {
      };
    },
    computed: {
    },
    methods: {
    }
  };
</script>
<style>
  .card {
    width: 200px;
  }
</style>
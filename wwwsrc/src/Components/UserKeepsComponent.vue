<template>
  <div class="ukeeps col-3 border">
    <div class="card">
      <button v-if="user.id" type="submit">Delete Keep</button>
      <router-link :to="{name: 'ukeep', params: {ukeepId: ukeep.id}}">{{ukeep.name}}</router-link>
      <!-- <p>{{ukeep.name}}</p> -->
      <p>{{ukeep.description}}</p>
    </div>
  </div>
</template>

<script>
  export default {
    name: "ukeeps",
    props: ['ukeep'],
    mounted() {
    },
    data() {
      return {
      };
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
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
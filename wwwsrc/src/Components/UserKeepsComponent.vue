<template>
  <div class="ukeeps col-3 border bg-light m-1 shadow">
    <!-- <div class="card"> -->
    <div>
      <button class="mx-auto" v-if="user.id" type="submit" @click='deleteKeep(ukeep.id)'>Delete Keep</button>
    </div>
    <router-link :to="{name: 'keeps', params: {keepId: ukeep.id}}">{{ukeep.name}}</router-link>
    <p>{{ukeep.description}}</p>
    <img :src="ukeep.img" class="image-fluid mx-auto" alt="">
    <!-- </div> -->
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
      deleteKeep(id) {
        return this.$store.dispatch('deleteKeep', id)
      },
    }
  };
</script>
<style>
  img {
    width: 150px;
    height: 150px;
  }

  .card {
    width: 200px;
  }
</style>
<template>
  <div class="keeps col-3 border bg-light m-1 shadow">
    <!-- <div class="card"> -->
    <router-link :to="{name: 'keeps', params: {keepId: keep.id}}">{{keep.name}}</router-link>
    <p>{{keep.description}}</p>
    <img :src="keep.img" class="image-fluid mx-auto" alt="">
    <!-- </div> -->
  </div>
</template>

<script>
  export default {
    name: "keeps",
    props: ['keep'],
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
  img {
    width: 120px;
    height: 120px;
  }

  .card {
    width: 200px;
  }
</style>
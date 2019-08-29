<template>
  <div class="keeps col-3 border">
    <div class="card">
      <p>{{keep.name}}</p>
      <p>{{keep.description}}</p>
    </div>
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
  .card {
    width: 200px;
  }
</style>
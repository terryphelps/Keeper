<template>
  <div>
    <div v-if="vaults.userId == user.userId" class="vault col-3 border">
      <div class="card">
        <p>{{vault.name}}</p>
        <p>{{vault.description}}</p>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "vault",
    props: ['vault'],
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
      vaults() {
        return this.$store.state.vaults;
      }
    },
    methods: {
    }
  };
</script>
<style>
  .vault {
    width: 200px;
  }
</style>
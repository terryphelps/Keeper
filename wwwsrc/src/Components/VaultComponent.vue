<template>
  <div class="vaults col-3 border bg-light m-1 shadow">
    <!-- <div class="card"> -->
    <div v-if="vaults.userId == user.userId" class="vault">
      <div class="row">
        <button class="mx-auto" v-if="user.id" type="submit" @click='deleteVault(vault.id)'>Delete
          Vault</button>
      </div>
      <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">{{vault.name}}</router-link>
      <p>{{vault.description}}</p>
    </div>
    <!-- </div> -->
  </div>
</template>

<script>
  export default {
    name: "vaults",
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
      deleteVault(id) {
        return this.$store.dispatch('deleteVault', id)
      },
    }
  };
</script>
<style>
  .vaults {
    /* width: 200px; */
    background-color: beige;
  }
</style>
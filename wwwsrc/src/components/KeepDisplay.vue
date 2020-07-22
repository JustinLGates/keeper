<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12 pt-3">
        <div class="card-columns">
          <Keep v-for="keep in publicKeeps" :key="keep.Id" :keepData="keep" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep";
export default {
  name: "home",
  mounted() {
    this.getAllVaultKeeps();
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.KeepsStore.keeps;
    },
    vaults() {
      return this.$store.state.VaultStore.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    async getAllVaultKeeps() {
      let arrvault = await this.$store.dispatch("getVaults", true);
      let allVaults = [];
      let arr = [];
      let data = {
        id: 0,
        done: false
      };

      for (let i = 0; i < arrvault.length; i++) {
        data.id = arrvault[i].id;
        arr = await this.$store.dispatch("getVaultKeeps", data);
        allVaults.push(...arr);
        console.log(arr);
        if (arrvault.length - 1 == i) {
          this.$store.dispatch("getUserVaultKeeps", allVaults);
        }
      }
    }
  },
  components: {
    Keep
  }
};
</script>
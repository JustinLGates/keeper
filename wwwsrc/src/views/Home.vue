<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="card-columns">
          <Keep v-for="keep in publicKeeps" :key="keep.id" :keepData="keep" />
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
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.KeepsStore.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Keep
  }
};
</script>

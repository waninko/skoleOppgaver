<template>
  <v-container>
    <v-layout row wrap>
      <v-flex xs12 >
        <v-carousel  v-responsive :height ="400" :width="500" >
          <v-carousel-item v-for="image in images"
                            :key="image.id"
                            :src="image.imageUrl"
               v-responsive :height ="400" :width="600">
          </v-carousel-item>
        </v-carousel>
      </v-flex>
    </v-layout>
  </v-container>
</template>


<script>
  export default {
    data() {
      return {
        images: [
          {
            imageUrl: 'https://img-s-msn-com.akamaized.net/tenant/amp/entityid/BBKHUZJ.img?h=832&w=1248&m=6&q=60&u=t&o=f&l=f&x=1733&y=1447',
            id: 'testtittel',
            title: 'kitten' },
          {
            imageUrl: 'https://i.pinimg.com/originals/e6/44/ea/e644eacfa75ecb5cb73e220bb0c7ef01.jpg',
            id: 'testtittel2',
            title: 'fox'
          },
          {
            imageUrl: 'https://static.tumblr.com/5cd69739caa23f0b0f5060d471dd52fb/hy5bknd/jXEnopfwv/tumblr_static_tumblr_static_7sjpty1w2roks004go80ksccs_640.jpg',
            id: 'testtittel3',
            title: 'greencheek'
          }
        ]
      }
    }
  }

</script>

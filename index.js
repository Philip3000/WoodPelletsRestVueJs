Vue.createApp({
    data() {
        return {
            items: [],
            addItemData: {id: 0, brand: "", price: 0, quality: 0},
            updateItem: {id: 0, brand: "", price: 0, quality: 0},
            Id: 0,
            Quality: 0,
            idItem: {},
            numberTo: 0,
            Brand: "",
            Price: 0,
            baseUrl: "https://restwoodpellets20230610142110.azurewebsites.net/api/woodpellet",
        }
    },
    async created() {
    await this.getAllItems();
  },
  methods: {
    async getAllItems() {
      try {
        const response = await axios.get(this.baseUrl);
        this.items = await response.data;
      } catch (ex) {
        alert(ex.message);
      }
    },
    async getById() {
        try {
            const response = await axios.get(this.baseUrl);
            this.items = await response.data;
            for (let i = 0; i < this.items.length; i++) {
                if (this.numberTo === this.items[i].id) {
                    this.idItem = this.items[i]
                }
            }
        }
        catch (ex) {
            alert(ex.message)
        }
    },
    async createNew() {
        try {
            response = await axios.post(this.baseUrl, this.addItemData)
            this.getAllItems()
        }
        catch (ex) {
            alert(ex.message)
        }
    },
    sortBrand() {
        this.items.sort((item1, item2) => item1.brand.localeCompare(item2.brand))
    },
    sortQualityAsc() {
        this.items.sort((item1, item2) => item1.quality - item2.quality)
    },
    async update() {
        try {
        console.log(this.updateItem)
        response = await axios.put(this.baseUrl + "/" + this.updateItem.id, this.updateItem)
        console.log(response)
        this.getAllItems()
        }
        catch (ex) {
            alert(ex.message)
        }
    }
  },
}).mount("#app")

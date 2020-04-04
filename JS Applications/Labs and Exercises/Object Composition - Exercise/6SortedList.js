function solve() {
    return {
        elements: [],
        add: function (element) {
            this.elements.push(element);
            this.elements.sort((a, b) => a - b);
        },
        remove: function (index) {
            if (index >= 0 && index <= this.elements.length - 1) {
                this.elements.splice(index, 1);
            }
        },
        get: function (index) {
            if (index >= 0 && index <= this.elements.length - 1) {
                return this.elements[index];
            }
        },
        get size() {
            return this.elements.length;
        }
    };
}
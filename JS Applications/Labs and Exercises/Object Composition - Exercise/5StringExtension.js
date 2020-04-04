(function () {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return `${str}${this}`;
        }

        return this.toString();
    };
    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return `${this}${str}`;
        }

        return this.toString();
    };
    String.prototype.isEmpty = function () {
        return this.length === 0;
    };
    String.prototype.truncate = function (n) {
        if (n >= this.length) {
            return this.toString();
        }
        if (n < 4) {
            return ".".repeat(n);
        }
        if (this.length > n) {
            let spaceIndex = this.substr(0, n - 2).lastIndexOf(" ");
            if (spaceIndex === -1) {
                return this.substr(0, n - 3) + "...";
            } else {
                return this.substr(0, spaceIndex).toString() + "...";
            }
        }
    };
    String.format = function (string, ...params) {
        params.forEach((el, i) => {
            string = string.replace(`{${i}}`, el);
        });
        return string;
    };
}());
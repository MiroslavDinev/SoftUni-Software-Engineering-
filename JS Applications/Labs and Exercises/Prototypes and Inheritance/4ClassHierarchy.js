function result() {
    class Figure {
        units = {
            m: 0.01,
            cm: 1,
            mm: 10
        }
        defaultUnit;

        constructor(unit) {
            this.defaultUnit = unit || 'cm';
        }

        caclWithUnit(x) {
            return x * this.units[this.defaultUnit];
        }
        get area() {
            return NaN;
        }
        toString() {
            return `Figures units: ${this.defaultUnit} Area: ${this.area}`;
        }
        changeUnits(x) {
            this.defaultUnit = x;
        }
    }

    class Circle extends Figure {
        radius = 0;

        constructor(r, unit) {
            super(unit);
            this.radius = r;
        }

        get area() {
            return Math.PI * Math.pow(this.caclWithUnit(this.radius), 2);
        }
        toString() {
            return super.toString() + ` - radius: ${(this.radius * this.units[this.defaultUnit])}`;
        }
    }

    class Rectangle extends Figure {
        width = 0;
        height = 0;

        constructor(w, h, unit) {
            super(unit);
            this.width = w;
            this.height = h;
        }

        get area() {
            return this.caclWithUnit(this.width) * this.caclWithUnit(this.height);
        }
        toString() {
            return super.toString() + ` - width: ${(this.width * this.units[this.defaultUnit])}, height: ${(this.height * this.units[this.defaultUnit])}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    };
}
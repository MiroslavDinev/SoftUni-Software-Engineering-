function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];

        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let output = `${super.toString()}\nRating: ${this.likes - this.dislikes}`;

            if (this.comments.length !== 0) {
                output += "\nComments:\n";
                for (let i = 0; i < this.comments.length; i++) {
                    let currComment = this.comments[i];
                    output += ` * ${currComment}\n`;
                }
            }

            return output.trim();
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return `${super.toString()}\nViews: ${this.views}`;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    };
}
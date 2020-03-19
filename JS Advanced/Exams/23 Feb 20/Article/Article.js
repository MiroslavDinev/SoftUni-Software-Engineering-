class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        let allLikes = 0;

        for (let i = 0; i < this._likes.length; i++) {
            let currUser = this._likes[i];
            allLikes += currUser.likes;
        }
        if (allLikes === 0) {
            return `${this.title} has 0 likes`;
        }

        if (allLikes === 1) {
            let username = this._likes.find(x => x.likes === 1);
            return `${username.username} likes this article!`;
        }

        return `${this._likes[0].username} and ${this._likes.length-1} others like this article!`;
    }

    like(username) {
        let foundUser = this._likes.find(x => x.username === username);

        if (foundUser) {
            throw new Error("You can't like the same article twice!");
        }

        if (username === this.creator) {
            throw new Error("You can't like your own articles!");
        }

        let user = {
            username,
            likes: 1
        };

        this._likes.push(user);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        let foundUser = this._likes.find(x => x.username === username);

        if (!foundUser || foundUser.likes === 0) {
            throw new Error("You can't dislike this article!");
        }

        foundUser.likes -= 1;

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let foundComment = this._comments.find(x => x.id === id);
        if (id === undefined || !foundComment) {
            let comment = {
                id: this._comments.length + 1,
                username,
                content,
                replies: []
            };

            this._comments.push(comment);

            return `${username} commented on ${this.title}`;
        }

        let reply = {
            id: `${id}.${foundComment.replies.length+1}`,
            username,
            content
        };

        foundComment.replies.push(reply);

        return "You replied successfully";
    }

    // toString(sortingType) {
    //     let result = "";
    //     let allLikes = 0;

    //     for (let i = 0; i < this._likes.length; i++) {
    //         let  currUser = this._likes[i];
    //         allLikes += currUser.likes;
    //     }
    //     if(sortingType==="username"){
    //         this._comments.sort((a,b)=> a.Username.localeCompare(b.Username));
    //         result += `Title: ${this.title}\n`;
    //         result += `Creator: ${this.creator}\n`;
    //         result += `Likes: ${allLikes}\n`;
    //         result += "Comments:\n";

    //         for (let i = 0; i < this._comments.length; i++) {
    //             let currComment = this._comments[i];
    //             result += `-- ${currComment.Id}. ${currComment.Username}: ${currComment.Content}\n`;
    //             currComment.Replies.sort((a,b)=>a.Username.localeCompare(b.Username));
    //             for (let i = 0; i < currComment.Replies.length; i++) {
    //                 let currReply = currComment.Replies[i];
    //                 result += `--- ${currReply.Id}. ${currReply.Username}: ${currReply.Content}\n`;
    //             }
    //         }
    //     }
    //     else if (sortingType === "asc"){
    //         this._comments.sort((a,b)=> a.Id-b.Id);
    //         result += `Title: ${this.title}\n`;
    //         result += `Creator: ${this.creator}\n`;
    //         result += `Likes: ${allLikes}\n`;
    //         result += "Comments:\n";

    //         for (let i = 0; i < this._comments.length; i++) {
    //             let currComment = this._comments[i];
    //             result += `-- ${currComment.Id}. ${currComment.Username}: ${currComment.Content}\n`;
    //             currComment.Replies.sort((a,b)=>a.Id-b.Id);
    //             for (let i = 0; i < currComment.Replies.length; i++) {
    //                 let currReply = currComment.Replies[i];
    //                 result += `--- ${currReply.Id}. ${currReply.Username}: ${currReply.Content}\n`;
    //             }
    //         }
    //     }
    //     else if (sortingType === "desc") {
    //         this._comments.sort((a,b)=> b.Id-a.Id);
    //         result += `Title: ${this.title}\n`;
    //         result += `Creator: ${this.creator}\n`;
    //         result += `Likes: ${allLikes}\n`;
    //         result += "Comments:\n";

    //         for (let i = 0; i < this._comments.length; i++) {
    //             let currComment = this._comments[i];
    //             result += `-- ${currComment.Id}. ${currComment.Username}: ${currComment.Content}\n`;
    //             currComment.Replies.sort((a,b)=>b.Id-a.Id);
    //             for (let i = 0; i < currComment.Replies.length; i++) {
    //                 let currReply = currComment.Replies[i];
    //                 result += `--- ${currReply.Id}. ${currReply.Username}: ${currReply.Content}\n`;
    //             }
    //         }
    //     }

    //     return result.trim();
    // }

    toString(sortingType) {
        let result = [];
        let allLikes = 0;

        for (let i = 0; i < this._likes.length; i++) {
            let currUser = this._likes[i];
            allLikes += currUser.likes;
        }
        if (sortingType === "username") {
            this._comments.sort((a, b) => a.username.localeCompare(b.username));
            result.push(`Title: ${this.title}`);
            result.push(`Creator: ${this.creator}`);
            result.push(`Likes: ${allLikes}`);
            result.push("Comments:");

            for (let i = 0; i < this._comments.length; i++) {
                let currComment = this._comments[i];
                result.push(`-- ${currComment.id}. ${currComment.username}: ${currComment.content}`);
                currComment.replies.sort((a, b) => a.username.localeCompare(b.username));
                for (let i = 0; i < currComment.replies.length; i++) {
                    let currReply = currComment.replies[i];
                    result.push(`--- ${currReply.id}. ${currReply.username}: ${currReply.content}`);
                }
            }
        } else if (sortingType === "asc") {
            this._comments.sort((a, b) => a.id - b.id);
            result.push(`Title: ${this.title}`);
            result.push(`Creator: ${this.creator}`);
            result.push(`Likes: ${allLikes}`);
            result.push("Comments:");

            for (let i = 0; i < this._comments.length; i++) {
                let currComment = this._comments[i];
                result.push(`-- ${currComment.id}. ${currComment.username}: ${currComment.content}`);
                currComment.replies.sort((a, b) => a.id - b.id);
                for (let i = 0; i < currComment.replies.length; i++) {
                    let currReply = currComment.replies[i];
                    result.push(`--- ${currReply.id}. ${currReply.username}: ${currReply.content}`);
                }
            }
        } else if (sortingType === "desc") {
            this._comments.sort((a, b) => b.id - a.id);
            result.push(`Title: ${this.title}`);
            result.push(`Creator: ${this.creator}`);
            result.push(`Likes: ${allLikes}`);
            result.push("Comments:");

            for (let i = 0; i < this._comments.length; i++) {
                let currComment = this._comments[i];
                result.push(`-- ${currComment.id}. ${currComment.username}: ${currComment.content}`);
                currComment.replies.sort((a, b) => b.id - a.id);
                for (let i = 0; i < currComment.replies.length; i++) {
                    let currReply = currComment.replies[i];
                    result.push(`--- ${currReply.id}. ${currReply.username}: ${currReply.content}`);
                }
            }
        }

        return result.join("\n");
    }
}
# Shard
Small binary delta compression library. [Not tested for production]

## Excerpt from Wikipedia
Binary Delta Compression technology allows a major reduction of download size by only transferring the difference between the old and the new files during the update process. (source: https://en.wikipedia.org/wiki/Binary_delta_compression)

## Be advised
This library wasn't tested in production, it may contain logical errors. At the time of writing this library (~3 years ago) it worked.

## History
This library was based other library, but unfortunatly, i can't remember which was it. At that time, i was making an app, that can create backup images from usb-drives, when they pluged-in, and my biggest concern was how that origin library was made. It was full of interfaces, very complex structure, too many stuff. I thought it doesn't have to be like that, so, i rewritten all the code in such way, that i could use it comfortably in my application. Though, the app was never finished...
